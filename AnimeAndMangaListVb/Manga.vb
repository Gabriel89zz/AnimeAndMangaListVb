Imports Newtonsoft.Json
Imports ClosedXML.Excel
Imports System.Xml
Imports Xceed.Words.NET
Imports Xceed.Document.NET
Imports System.IO
Friend Class Manga
    Inherits Book
    Implements IJapaneseWorks
    Private _title As String
    Public Property Title As String Implements IJapaneseWorks.Title
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
        End Set
    End Property

    Private _author As String
    Public ReadOnly Property Author As String Implements IJapaneseWorks.Author
        Get
            Return _author
        End Get
    End Property

    Private _genre As String
    Public Property Genre As String Implements IJapaneseWorks.Genre
        Get
            Return _genre
        End Get
        Set(value As String)
            _genre = value
        End Set
    End Property

    Private _releaseyear As Date
    Public ReadOnly Property ReleaseYear As Date Implements IJapaneseWorks.ReleaseYear
        Get
            Return _releaseyear
        End Get
    End Property

    Private _rating As Integer
    Public Property Rating As Integer Implements IJapaneseWorks.Rating
        Get
            Return _rating
        End Get
        Set(value As Integer)
            _rating = value
        End Set
    End Property

    'CONSTRUCTOR SIN PARAMETROS
    Public Sub New()
        MyBase.New()
        _title = ""
        _author = ""
        _genre = ""
        _releaseyear = Date.MinValue
        _rating = 0
    End Sub

    'CONSTRUCTOR CON PARAMETROS
    Public Sub New(title As String, autor As String, genre As String, releaseyear As Date, chaptersnumber As Integer, editorial As String, rating As Integer, price As Double)
        MyBase.New(chaptersnumber, editorial, price)
        _title = title
        _author = autor
        _genre = genre
        _releaseyear = releaseyear
        _rating = rating
    End Sub

    'Polimorfimso
    Public Overrides Function ToString() As String
        Return "Title: " & _title & ", Author: " & _author & ", Genre: " & _genre & ", Acquisition Date: " & _releaseyear.ToString().ToString() & ", Volume: " + Volume.ToString() & ", Editorial: " + Editorial.ToString() & ", Price: " + Price.ToString() & ", Rating:" + _rating
    End Function

    ' METODO QUE REGRESA PERO NO RECIBE
    Public Shared Function GetMangaGenres() As String()
        Dim MangaGenres = {"Shonen", "Seinen", "Comedy", "Drama", "Sci-Fi", "Romcom", "Slice of Life", "Isekai"}
        Return MangaGenres
    End Function

    Public Shared Sub ExportMangaToJson(filePath As String, mangas As Manga())
        Dim mangaList As List(Of Manga) = mangas.Where(Function(m) m IsNot Nothing).ToList()
        Dim json As String = JsonConvert.SerializeObject(mangaList, Newtonsoft.Json.Formatting.Indented)
        File.WriteAllText(filePath, json)
    End Sub


    Public Shared Sub ExportMangaToXml(filePath As String, mangas As Manga())
        Dim mangaList As List(Of Manga) = mangas.Where(Function(m) m IsNot Nothing).ToList()
        Dim doc As XmlDocument = New XmlDocument()
        Dim root As XmlElement = doc.CreateElement("Mangas")
        doc.AppendChild(root)

        For Each manga In mangaList
            Dim mangaElement As XmlElement = doc.CreateElement("Manga")

            Dim titleElement As XmlElement = doc.CreateElement("Title")
            titleElement.InnerText = manga.Title
            mangaElement.AppendChild(titleElement)

            Dim authorElement As XmlElement = doc.CreateElement("Author")
            authorElement.InnerText = manga.Author
            mangaElement.AppendChild(authorElement)

            Dim genreElement As XmlElement = doc.CreateElement("Genre")
            genreElement.InnerText = manga.Genre
            mangaElement.AppendChild(genreElement)

            Dim releaseYearElement As XmlElement = doc.CreateElement("ReleaseYear")
            releaseYearElement.InnerText = manga.ReleaseYear.ToShortDateString()
            mangaElement.AppendChild(releaseYearElement)

            Dim volumeElement As XmlElement = doc.CreateElement("Volume")
            volumeElement.InnerText = manga.Volume.ToString()
            mangaElement.AppendChild(volumeElement)

            Dim editorialElement As XmlElement = doc.CreateElement("Editorial")
            editorialElement.InnerText = manga.Editorial
            mangaElement.AppendChild(editorialElement)

            Dim ratingElement As XmlElement = doc.CreateElement("Rating")
            ratingElement.InnerText = manga.Rating.ToString()
            mangaElement.AppendChild(ratingElement)

            root.AppendChild(mangaElement)
        Next

        doc.Save(filePath)
    End Sub

    Public Shared Sub ExportMangaToExcel(filePath As String, mangas As Manga())
        Dim mangaList As List(Of Manga) = mangas.Where(Function(m) m IsNot Nothing).ToList()
        Using workbook = New XLWorkbook()
            Dim worksheet = workbook.Worksheets.Add("Mangas")

            worksheet.Cell(1, 1).Value = "Title"
            worksheet.Cell(1, 2).Value = "Author"
            worksheet.Cell(1, 3).Value = "Genre"
            worksheet.Cell(1, 4).Value = "ReleaseYear"
            worksheet.Cell(1, 5).Value = "Volume"
            worksheet.Cell(1, 6).Value = "Editorial"
            worksheet.Cell(1, 7).Value = "Rating"

            For i = 0 To mangaList.Count - 1
                Dim manga = mangaList(i)
                worksheet.Cell(i + 2, 1).Value = manga.Title
                worksheet.Cell(i + 2, 2).Value = manga.Author
                worksheet.Cell(i + 2, 3).Value = manga.Genre
                worksheet.Cell(i + 2, 4).Value = manga.ReleaseYear.ToShortDateString()
                worksheet.Cell(i + 2, 5).Value = manga.Volume
                worksheet.Cell(i + 2, 6).Value = manga.Editorial
                worksheet.Cell(i + 2, 7).Value = manga.Rating
            Next

            workbook.SaveAs(filePath)
        End Using
    End Sub

    Public Shared Sub ExportMangaToWord(filePath As String, mangas As Manga())
        Dim mangaList As List(Of Manga) = mangas.Where(Function(m) m IsNot Nothing).ToList()
        Using document = DocX.Create(filePath)
            document.InsertParagraph("Manga List").FontSize(15).Bold().Alignment = Alignment.center
            Dim table = document.AddTable(mangaList.Count + 1, 7)

            table.Rows(0).Cells(0).Paragraphs(0).Append("Title")
            table.Rows(0).Cells(1).Paragraphs(0).Append("Author")
            table.Rows(0).Cells(2).Paragraphs(0).Append("Genre")
            table.Rows(0).Cells(3).Paragraphs(0).Append("ReleaseYear")
            table.Rows(0).Cells(4).Paragraphs(0).Append("Volume")
            table.Rows(0).Cells(5).Paragraphs(0).Append("Editorial")
            table.Rows(0).Cells(6).Paragraphs(0).Append("Rating")

            For i = 0 To mangaList.Count - 1
                Dim manga = mangaList(i)
                table.Rows(i + 1).Cells(0).Paragraphs(0).Append(manga.Title)
                table.Rows(i + 1).Cells(1).Paragraphs(0).Append(manga.Author)
                table.Rows(i + 1).Cells(2).Paragraphs(0).Append(manga.Genre)
                table.Rows(i + 1).Cells(3).Paragraphs(0).Append(manga.ReleaseYear.ToShortDateString())
                table.Rows(i + 1).Cells(4).Paragraphs(0).Append(manga.Volume.ToString())
                table.Rows(i + 1).Cells(5).Paragraphs(0).Append(manga.Editorial)
                table.Rows(i + 1).Cells(6).Paragraphs(0).Append(manga.Rating.ToString())
            Next

            document.InsertTable(table)
            document.Save()
        End Using
    End Sub

    Public Shared Sub ExportMangaToTxt(filePath As String, mangas As Manga())
        Dim mangaList As List(Of Manga) = mangas.Where(Function(m) m IsNot Nothing).ToList()
        Using writer As StreamWriter = New StreamWriter(filePath)
            For Each manga In mangaList
                writer.WriteLine(manga.ToString())
            Next
        End Using
    End Sub

    Public Shared Sub LoadMangaDataFromTextFile(filePath As String, mangas As Manga(), lstvData As ListView)
        Try
            Dim lines = File.ReadAllLines(filePath)

            For Each line In lines
                Dim fields = line.Split("|"c)

                Dim emptyIndex = Array.FindIndex(mangas, Function(m) m Is Nothing)

                If emptyIndex = -1 Then
                    MessageBox.Show("The array is full. You need to delete some entries to add new ones.", "Array Full", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                mangas(emptyIndex) = New Manga(fields(0), fields(1), fields(2), Date.Parse(fields(3)), Convert.ToInt32(fields(4)), fields(5), Convert.ToInt32(fields(6)), Convert.ToDouble(fields(7)))

                Dim item As ListViewItem = New ListViewItem(mangas(emptyIndex).Title)
                item.SubItems.Add(mangas(emptyIndex).Author)
                item.SubItems.Add(mangas(emptyIndex).Genre)
                item.SubItems.Add(mangas(emptyIndex).ReleaseYear.ToShortDateString())
                item.SubItems.Add(mangas(emptyIndex).Volume.ToString())
                item.SubItems.Add(mangas(emptyIndex).Editorial)
                item.SubItems.Add(mangas(emptyIndex).Rating.ToString())

                lstvData.Items.Add(item)
            Next

            MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

End Class
