Imports Newtonsoft.Json
Imports ClosedXML.Excel
Imports System.Xml
Imports Xceed.Words.NET
Imports Xceed.Document.NET
Imports System.IO
Friend Class Anime
    Inherits TVShow
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

    Public Sub New()
        MyBase.New()
        _title = ""
        _author = ""
        _genre = ""
        _releaseyear = Date.MinValue
        _rating = 0
    End Sub

    Public Sub New(title As String, autor As String, genre As String, releaseyear As Date, numberofseasons As Integer, production As String, platform As String, rating As Integer)
        MyBase.New(production, numberofseasons, platform)
        _title = title
        _author = autor
        _genre = genre
        _releaseyear = releaseyear
        _rating = rating
    End Sub

    Public Overrides Function ToString() As String
        Return "Title: " & _title & ", Author: " & _author & ", Genre: " & _genre & ", Release Date: " & _releaseyear.ToString() & ", Number of Seasons: " & NumberOfSeasons.ToString().ToString() & ", Production Studio: " + ProductionStudio.ToString() & ", Platform: " + Platform.ToString() & ", Rating:" + _rating
    End Function

    Public Shared Sub ExportAnimeToJson(filePath As String, animeMatriz As Anime(,))
        Dim animeList As List(Of Anime) = New List(Of Anime)()
        For Each anime In animeMatriz
            If anime IsNot Nothing Then
                animeList.Add(anime)
            End If
        Next
        Dim json As String = JsonConvert.SerializeObject(animeList, Newtonsoft.Json.Formatting.Indented)
        File.WriteAllText(filePath, json)
    End Sub

    Public Shared Sub ExportAnimeToXml(filePath As String, animeMatriz As Anime(,))
        Dim doc As XmlDocument = New XmlDocument()
        Dim root = doc.CreateElement("Animes")
        doc.AppendChild(root)

        For row = 0 To animeMatriz.GetLength(0) - 1
            For col = 0 To animeMatriz.GetLength(1) - 1
                If animeMatriz(row, col) IsNot Nothing Then
                    Dim animeElement = doc.CreateElement("Anime")

                    Dim titleElement = doc.CreateElement("Title")
                    titleElement.InnerText = animeMatriz(row, col).Title
                    animeElement.AppendChild(titleElement)

                    Dim authorElement = doc.CreateElement("Author")
                    authorElement.InnerText = animeMatriz(row, col).Author
                    animeElement.AppendChild(authorElement)

                    Dim genreElement = doc.CreateElement("Genre")
                    genreElement.InnerText = animeMatriz(row, col).Genre
                    animeElement.AppendChild(genreElement)

                    Dim releaseYearElement = doc.CreateElement("ReleaseYear")
                    releaseYearElement.InnerText = animeMatriz(row, col).ReleaseYear.ToShortDateString()
                    animeElement.AppendChild(releaseYearElement)

                    Dim numberOfSeasonsElement = doc.CreateElement("NumberOfSeasons")
                    numberOfSeasonsElement.InnerText = animeMatriz(row, col).NumberOfSeasons.ToString()
                    animeElement.AppendChild(numberOfSeasonsElement)

                    Dim platformElement = doc.CreateElement("Platform")
                    platformElement.InnerText = animeMatriz(row, col).Platform
                    animeElement.AppendChild(platformElement)

                    Dim productionStudioElement = doc.CreateElement("ProductionStudio")
                    productionStudioElement.InnerText = animeMatriz(row, col).ProductionStudio
                    animeElement.AppendChild(productionStudioElement)

                    Dim ratingElement = doc.CreateElement("Rating")
                    ratingElement.InnerText = animeMatriz(row, col).Rating.ToString()
                    animeElement.AppendChild(ratingElement)

                    root.AppendChild(animeElement)
                End If
            Next
        Next

        doc.Save(filePath)
    End Sub

    Public Shared Sub ExportAnimeToExcel(filePath As String, animeMatriz As Anime(,))
        Using workbook = New XLWorkbook()
            Dim worksheet = workbook.Worksheets.Add("Animes")

            worksheet.Cell(1, 1).Value = "Title"
            worksheet.Cell(1, 2).Value = "Author"
            worksheet.Cell(1, 3).Value = "Genre"
            worksheet.Cell(1, 4).Value = "ReleaseYear"
            worksheet.Cell(1, 5).Value = "NumberOfSeasons"
            worksheet.Cell(1, 6).Value = "Platform"
            worksheet.Cell(1, 7).Value = "ProductionStudio"
            worksheet.Cell(1, 8).Value = "Rating"

            Dim row = 2
            For i = 0 To animeMatriz.GetLength(0) - 1
                For j = 0 To animeMatriz.GetLength(1) - 1
                    If animeMatriz(i, j) IsNot Nothing Then
                        worksheet.Cell(row, 1).Value = animeMatriz(i, j).Title
                        worksheet.Cell(row, 2).Value = animeMatriz(i, j).Author
                        worksheet.Cell(row, 3).Value = animeMatriz(i, j).Genre
                        worksheet.Cell(row, 4).Value = animeMatriz(i, j).ReleaseYear.ToShortDateString()
                        worksheet.Cell(row, 5).Value = animeMatriz(i, j).NumberOfSeasons
                        worksheet.Cell(row, 6).Value = animeMatriz(i, j).Platform
                        worksheet.Cell(row, 7).Value = animeMatriz(i, j).ProductionStudio
                        worksheet.Cell(row, 8).Value = animeMatriz(i, j).Rating.ToString()
                        row += 1
                    End If
                Next
            Next

            workbook.SaveAs(filePath)
        End Using
    End Sub


    Public Shared Sub ExportAnimeToWord(filePath As String, animeMatriz As Anime(,))
        Using document = DocX.Create(filePath)
            document.InsertParagraph("Anime List").FontSize(15).Bold().Alignment = Alignment.center
            Dim table = document.AddTable(1, 8)

            table.Rows(0).Cells(0).Paragraphs(0).Append("Title")
            table.Rows(0).Cells(1).Paragraphs(0).Append("Author")
            table.Rows(0).Cells(2).Paragraphs(0).Append("Genre")
            table.Rows(0).Cells(3).Paragraphs(0).Append("ReleaseYear")
            table.Rows(0).Cells(4).Paragraphs(0).Append("NumberOfSeasons")
            table.Rows(0).Cells(5).Paragraphs(0).Append("Platform")
            table.Rows(0).Cells(6).Paragraphs(0).Append("ProductionStudio")
            table.Rows(0).Cells(7).Paragraphs(0).Append("Rating")

            Dim row = 1
            For i = 0 To animeMatriz.GetLength(0) - 1
                For j = 0 To animeMatriz.GetLength(1) - 1
                    If animeMatriz(i, j) IsNot Nothing Then
                        table.InsertRow()
                        table.Rows(row).Cells(0).Paragraphs(0).Append(animeMatriz(i, j).Title)
                        table.Rows(row).Cells(1).Paragraphs(0).Append(animeMatriz(i, j).Author)
                        table.Rows(row).Cells(2).Paragraphs(0).Append(animeMatriz(i, j).Genre)
                        table.Rows(row).Cells(3).Paragraphs(0).Append(animeMatriz(i, j).ReleaseYear.ToShortDateString())
                        table.Rows(row).Cells(4).Paragraphs(0).Append(animeMatriz(i, j).NumberOfSeasons.ToString())
                        table.Rows(row).Cells(5).Paragraphs(0).Append(animeMatriz(i, j).Platform)
                        table.Rows(row).Cells(6).Paragraphs(0).Append(animeMatriz(i, j).ProductionStudio)
                        table.Rows(row).Cells(7).Paragraphs(0).Append(animeMatriz(i, j).Rating.ToString())
                        row += 1
                    End If
                Next
            Next

            document.InsertTable(table)
            document.Save()
        End Using
    End Sub

    Public Shared Sub ExportAnimeToTxt(filePath As String, animeMatriz As Anime(,))
        Using writer As StreamWriter = New StreamWriter(filePath)
            For i = 0 To animeMatriz.GetLength(0) - 1
                For j = 0 To animeMatriz.GetLength(1) - 1
                    If animeMatriz(i, j) IsNot Nothing Then
                        writer.WriteLine(animeMatriz(i, j).ToString())
                    End If
                Next
            Next
        End Using
    End Sub
End Class
