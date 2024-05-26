Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports ClosedXML.Excel
Imports iText.Layout.Font
Imports System.Xml
Imports Xceed.Words.NET
Imports Xceed.Document.NET
Imports System.IO
Friend Class Manga
    Inherits Book
    Implements IJapaneseWorks
    Private titleField As String
    Public Property Title As String Implements IJapaneseWorks.Title
        Get
            Return titleField
        End Get
        Set(value As String)
            titleField = value
        End Set
    End Property

    Private authorField As String
    Public ReadOnly Property Author As String Implements IJapaneseWorks.Author
        Get
            Return authorField
        End Get
    End Property

    Private genreField As String
    Public Property Genre As String Implements IJapaneseWorks.Genre
        Get
            Return genreField
        End Get
        Set(value As String)
            genreField = value
        End Set
    End Property

    Private releaseyearField As Date
    Public ReadOnly Property ReleaseYear As Date Implements IJapaneseWorks.ReleaseYear
        Get
            Return releaseyearField
        End Get
    End Property

    Private ratingField As Integer
    Public Property Rating As Integer Implements IJapaneseWorks.Rating
        Get
            Return ratingField
        End Get
        Set(value As Integer)
            ratingField = value
        End Set
    End Property

    'CONSTRUCTOR SIN PARAMETROS
    Public Sub New()
        MyBase.New()
        titleField = ""
        authorField = ""
        genreField = ""
        releaseyearField = Date.MinValue
        ratingField = 0
    End Sub

    'CONSTRUCTOR CON PARAMETROS
    Public Sub New(title As String, autor As String, genre As String, releaseyear As Date, chaptersnumber As Integer, editorial As String, rating As Integer, price As Double)
        MyBase.New(chaptersnumber, editorial, price)
        titleField = title
        authorField = autor
        genreField = genre
        releaseyearField = releaseyear
        ratingField = rating
    End Sub

    'Polimorfimso
    Public Overrides Function ToString() As String
        Return "Title: " & titleField & ", Author: " & authorField & ", Genre: " & genreField & ", Acquisition Date: " & releaseyearField.ToString().ToString() & ", Volume: " + Volume.ToString() & ", Editorial: " + Editorial.ToString() & ", Price: " + Price.ToString() & ", Rating:" + ratingField
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
End Class
