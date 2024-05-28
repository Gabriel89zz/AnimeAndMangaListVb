Imports System.IO
Partial Public Class Form1
    Private mangas As Manga()
    Private animeMatriz As Anime(,)
    Private index As Integer
    Private row As Integer
    Private column As Integer
    Public Sub New()
        InitializeComponent()
        index = 0
        mangas = New Manga(99) {}
        row = 0
        column = 0
        animeMatriz = New Anime(9, 9) {}

        txtAuthor.Visible = False
        txtChapters.Visible = False
        nudRating.Visible = False
        txtPrice.Visible = False
        dtpDate.Visible = False
        txtTitle.Visible = False
        cbGenre.Visible = False
        cbEditorial.Visible = False

        lblAuthor.Visible = False
        lblChapters.Visible = False
        lblRating.Visible = False
        lblPrice.Visible = False
        lblDate.Visible = False
        lblTitle.Visible = False
        lblGenre.Visible = False
        lblEditorial.Visible = False
        lblAddReview.Visible = False

        lstvData.Visible = False
        btnSaveManga.Visible = False
        btnCalculateCost.Visible = False
        btnDeleteManga.Visible = False
        btnSaveAnime.Visible = False
        btnExport.Visible = False
        txtReview.Visible = False
        btnSaveReview.Visible = False
        btnLoadData.Visible = False
    End Sub

    Private Sub btnSaveManga_Click(sender As Object, e As EventArgs)
        Dim chapters As Integer = Nothing, price As Double = Nothing
        Try
            If String.IsNullOrWhiteSpace(txtTitle.Text) OrElse String.IsNullOrWhiteSpace(txtAuthor.Text) OrElse String.IsNullOrWhiteSpace(cbGenre.Text) OrElse String.IsNullOrWhiteSpace(txtChapters.Text) OrElse String.IsNullOrWhiteSpace(cbEditorial.Text) OrElse String.IsNullOrWhiteSpace(txtPrice.Text) Then
                MessageBox.Show("All fields must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If

            If dtpDate.Value > Date.Now Then
                MessageBox.Show("The selected date cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If

            If Not Integer.TryParse(txtChapters.Text, chapters) OrElse chapters < 0 Then
                MessageBox.Show("Chapters must be a non-negative integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If

            If Not Double.TryParse(txtPrice.Text, price) OrElse price < 0 Then
                MessageBox.Show("Check that the price does not contain letters and that it does not contain a negative value", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If

            Dim emptyIndex = Array.FindIndex(mangas, Function(m) m Is Nothing)

            If emptyIndex = -1 Then
                MessageBox.Show("The array is full. You need to delete some entries to add new ones.", "Array Full", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            mangas(emptyIndex) = New Manga(txtTitle.Text, txtAuthor.Text, cbGenre.Text, dtpDate.Value, Convert.ToInt32(txtChapters.Text), cbEditorial.Text, Convert.ToInt32(nudRating.Value), Convert.ToDouble(txtPrice.Text))

            Dim item As ListViewItem = New ListViewItem(mangas(emptyIndex).Title)
            item.SubItems.Add(mangas(emptyIndex).Author)
            item.SubItems.Add(mangas(emptyIndex).Genre)
            item.SubItems.Add(mangas(emptyIndex).ReleaseYear.ToShortDateString())
            item.SubItems.Add(mangas(emptyIndex).Volume.ToString())
            item.SubItems.Add(mangas(emptyIndex).Editorial)
            item.SubItems.Add(mangas(emptyIndex).Rating.ToString())

            lstvData.Items.Add(item)
            ClearTxts()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCalculateCost_Click(sender As Object, e As EventArgs)
        If btnAddAnime.Visible = True Then
            MessageBox.Show("The cost of your manga collection is: " & Manga.GetCollectionCost(mangas).ToString().ToString() & " MXN", "Cost of Collection", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            TVShow.CalulateCostSubscription(animeMatriz)
        End If
    End Sub

    Private Sub ShowLabelsAndButtons()
        txtAuthor.Visible = True
        txtChapters.Visible = True
        nudRating.Visible = True
        txtPrice.Visible = True
        dtpDate.Visible = True
        txtTitle.Visible = True
        cbGenre.Visible = True
        lblAuthor.Visible = True
        lblChapters.Visible = True
        lblRating.Visible = True
        lblPrice.Visible = True
        lblDate.Visible = True
        lblTitle.Visible = True
        lblGenre.Visible = True
        lblEditorial.Visible = True
        cbEditorial.Visible = True
        lstvData.Visible = True
        btnCalculateCost.Visible = True
        btnDeleteManga.Visible = True
        btnExport.Visible = True
        lblAddReview.Visible = True
        txtReview.Visible = True
        btnSaveReview.Visible = True
        btnLoadData.Visible = True
        lstvData.View = View.Details
        lstvData.Columns.Add("Title", 100)
        lstvData.Columns.Add("Author", 100)
        lstvData.Columns.Add("Genre", 100)
        lstvData.Columns.Add("Date", 100)
        Dim MangaGenres As String() = Manga.GetMangaGenres()
        cbGenre.DataSource = MangaGenres
    End Sub

    'METODO QUE NO RECIBE NI REGRESA
    Private Sub ClearTxts()
        txtAuthor.Text = ""
        txtChapters.Text = ""
        cbGenre.Text = ""
        txtPrice.Text = ""
        txtTitle.Text = ""
        nudRating.Value = 0
        dtpDate.Value = Date.Now
        cbEditorial.Text = ""
    End Sub

    Private Sub btnAddManga_Click(sender As Object, e As EventArgs)
        lstvData.Items.Clear()
        lstvData.Columns.Clear()
        ShowLabelsAndButtons()
        lstvData.Columns.Add("Volume", 100)
        lstvData.Columns.Add("Editorial", 100)
        lstvData.Columns.Add("Rating", 100)
        lblChapters.Text = "Volume:"
        lblEditorial.Text = "Editorial:"
        lblPrice.Text = "Price:"
        lblDate.Text = "Acquisition Date:"
        btnSaveManga.Visible = True
        btnSaveAnime.Visible = False
        btnAddManga.Visible = False
        btnAddAnime.Visible = True
        cbEditorial.Items.Clear()
        cbEditorial.Items.AddRange(New Object() {"Panini", "Ivrea", "Norma", "Kamite"})
        ClearTxts()
    End Sub


    Private Sub btnAddAnime_Click(sender As Object, e As EventArgs)
        lstvData.Items.Clear()
        lstvData.Columns.Clear()
        ShowLabelsAndButtons()
        lstvData.Columns.Add("Number of Seasons", 100)
        lstvData.Columns.Add("Production Studio", 100)
        lstvData.Columns.Add("Platform", 100)
        lstvData.Columns.Add("Rating", 100)
        lblChapters.Text = "Number of Seasons:"
        lblEditorial.Text = "Platform:"
        lblPrice.Text = "Production Studio:"
        lblDate.Text = "Viewed date:"
        btnSaveAnime.Visible = True
        btnSaveManga.Visible = False
        btnAddAnime.Visible = False
        btnAddManga.Visible = True
        cbEditorial.Items.Clear()
        cbEditorial.Items.AddRange(New Object() {"Crunchyroll", "Netflix", "Prime Video", "Disney Plus"})
        ClearTxts()
    End Sub

    Private Sub btnSaveAnime_Click(sender As Object, e As EventArgs)

        Dim episodes As Integer = Nothing
        Try
            If String.IsNullOrWhiteSpace(txtTitle.Text) OrElse String.IsNullOrWhiteSpace(txtAuthor.Text) OrElse String.IsNullOrWhiteSpace(cbGenre.Text) OrElse String.IsNullOrWhiteSpace(txtChapters.Text) OrElse String.IsNullOrWhiteSpace(cbEditorial.Text) OrElse String.IsNullOrWhiteSpace(txtPrice.Text) Then
                MessageBox.Show("All fields must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If

            If dtpDate.Value > Date.Now Then
                MessageBox.Show("The selected date cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If

            If Not Integer.TryParse(txtChapters.Text, episodes) OrElse episodes < 0 Then
                MessageBox.Show("Episodes must be a non-negative integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If


            Dim added = False
            row = 0

            While row < animeMatriz.GetLength(0)
                column = 0

                While column < animeMatriz.GetLength(1)
                    If animeMatriz(row, column) Is Nothing Then
                        animeMatriz(row, column) = New Anime(txtTitle.Text, txtAuthor.Text, cbGenre.Text, dtpDate.Value, Convert.ToInt32(txtChapters.Text), txtPrice.Text, cbEditorial.Text, Convert.ToInt32(nudRating.Value))

                        Dim item As ListViewItem = New ListViewItem(animeMatriz(row, column).Title)
                        item.SubItems.Add(animeMatriz(row, column).Author)
                        item.SubItems.Add(animeMatriz(row, column).Genre)
                        item.SubItems.Add(animeMatriz(row, column).ReleaseYear.ToShortDateString())
                        item.SubItems.Add(animeMatriz(row, column).NumberOfSeasons.ToString())
                        item.SubItems.Add(animeMatriz(row, column).ProductionStudio)
                        item.SubItems.Add(animeMatriz(row, column).Platform.ToString())
                        item.SubItems.Add(animeMatriz(row, column).Rating.ToString())

                        lstvData.Items.Add(item)
                        ClearTxts()
                        added = True
                        Exit While
                    End If

                    column += 1
                End While
                If added Then
                    Exit While
                End If

                row += 1
            End While

            If Not added Then
                MessageBox.Show("The matrix is full. You need to delete some entries to add new ones.", "Matrix Full", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDeleteManga_Click(sender As Object, e As EventArgs)
        If btnAddAnime.Visible = True Then
            If lstvData.SelectedItems.Count > 0 Then
                Dim indicesToRemove As List(Of Integer) = New List(Of Integer)()
                For Each item As ListViewItem In lstvData.SelectedItems
                    indicesToRemove.Add(item.Index)
                Next

                indicesToRemove.Sort()
                indicesToRemove.Reverse()

                For Each selectedIndex In indicesToRemove
                    lstvData.Items.RemoveAt(selectedIndex)
                    Me.mangas(selectedIndex) = Nothing
                Next

                MessageBox.Show("Selected mangas have been deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please select a manga to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            If lstvData.SelectedItems.Count > 0 Then
                For Each selectedItem As ListViewItem In lstvData.SelectedItems
                    Dim selectedIndex As Integer = selectedItem.Index
                    lstvData.Items.RemoveAt(selectedIndex)

                    Dim rowToDelete As Integer = selectedIndex / animeMatriz.GetLength(1)
                    Dim columnToDelete = selectedIndex Mod animeMatriz.GetLength(1)

                    If rowToDelete < animeMatriz.GetLength(0) AndAlso columnToDelete < animeMatriz.GetLength(1) Then
                        Me.animeMatriz(rowToDelete, columnToDelete) = Nothing
                    Else
                        MessageBox.Show("Error: Selected index out of range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End If
                Next

                MessageBox.Show("Selected animes have been deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please select an item to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs)
        If btnAddAnime.Visible = True Then
            Using sfd As SaveFileDialog = New SaveFileDialog()
                sfd.Filter = "JSON Files|*.json|XML Files|*.xml|Excel Files|*.xlsx|Word Files|*.docx|PDF Files|*.pdf|Text Files|*.txt"
                sfd.Title = "Save an Export File"
                sfd.FileName = "ExportedData"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim filePath As String = sfd.FileName
                    Dim extension = Path.GetExtension(filePath)

                    Select Case extension.ToLower()
                        Case ".json"
                            Manga.ExportMangaToJson(filePath, mangas)
                        Case ".xml"
                            Manga.ExportMangaToXml(filePath, mangas)
                        Case ".xlsx"
                            Manga.ExportMangaToExcel(filePath, mangas)
                        Case ".docx"
                            Manga.ExportMangaToWord(filePath, mangas)
                            'case ".pdf":
                            '    ExportMangaToPdf(filePath);
                            '    break;
                        Case ".txt"
                            Manga.ExportMangaToTxt(filePath, mangas)
                        Case Else
                            MessageBox.Show("Unsupported file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Select

                    MessageBox.Show("Data exported successfully to " & filePath, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Else
            Using sfd As SaveFileDialog = New SaveFileDialog()
                sfd.Filter = "JSON Files|*.json|XML Files|*.xml|Excel Files|*.xlsx|Word Files|*.docx|PDF Files|*.pdf|Text Files|*.txt"
                sfd.Title = "Save an Export File"
                sfd.FileName = "ExportedData"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim filePath As String = sfd.FileName
                    Dim extension = Path.GetExtension(filePath)

                    Select Case extension.ToLower()
                        Case ".json"
                            Anime.ExportAnimeToJson(filePath, animeMatriz)
                        Case ".xml"
                            Anime.ExportAnimeToXml(filePath, animeMatriz)
                        Case ".xlsx"
                            Anime.ExportAnimeToExcel(filePath, animeMatriz)
                        Case ".docx"
                            Anime.ExportAnimeToWord(filePath, animeMatriz)
                        Case ".txt"
                            'case ".pdf":
                            '    ExportAnimeToPdf(filePath);
                            '    break;
                            Anime.ExportAnimeToTxt(filePath, animeMatriz)
                        Case Else
                            MessageBox.Show("Unsupported file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Select

                    MessageBox.Show("Data exported successfully to " & filePath, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End If
    End Sub


    Private Sub btnSaveReview_Click(sender As Object, e As EventArgs)
        Try
            Dim saveFileDialog1 As SaveFileDialog = New SaveFileDialog()

            saveFileDialog1.Title = "Save Review File"
            saveFileDialog1.DefaultExt = "txt"
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = saveFileDialog1.FileName

                File.WriteAllText(filePath, txtReview.Text)

                MessageBox.Show("Review saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the review: " & ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnLoadData_Click(sender As Object, e As EventArgs)
        Using openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "TXT files (*.txt)|*.txt"
            openFileDialog.RestoreDirectory = True

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = openFileDialog.FileName
                If btnAddAnime.Visible = True Then
                    LoadDataFromTXT(filePath)
                Else
                    LoadAnimeDataFromTextFile(filePath)
                End If
            End If
        End Using
    End Sub

    Private Sub LoadDataFromTXT(filePath As String)
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
            MessageBox.Show("An error occurred while loading data: " & ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub LoadAnimeDataFromTextFile(filePath As String)
        Try
            Dim lines = File.ReadAllLines(filePath)

            row = 0
            column = 0
            For Each line In lines
                Dim fields = line.Split("|"c)

                If row >= animeMatriz.GetLength(0) OrElse column >= animeMatriz.GetLength(1) Then
                    MessageBox.Show("The matrix is full. You need to delete some entries to add new ones.", "Matrix Full", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                animeMatriz(row, column) = New Anime(fields(0), fields(1), fields(2), Date.Parse(fields(3)), Convert.ToInt32(fields(4)), fields(5), fields(6), Convert.ToInt32(fields(7)))

                Dim item As ListViewItem = New ListViewItem(animeMatriz(row, column).Title)
                item.SubItems.Add(animeMatriz(row, column).Author)
                item.SubItems.Add(animeMatriz(row, column).Genre)
                item.SubItems.Add(animeMatriz(row, column).ReleaseYear.ToShortDateString())
                item.SubItems.Add(animeMatriz(row, column).NumberOfSeasons.ToString())
                item.SubItems.Add(animeMatriz(row, column).ProductionStudio)
                item.SubItems.Add(animeMatriz(row, column).Platform.ToString())
                item.SubItems.Add(animeMatriz(row, column).Rating.ToString())

                lstvData.Items.Add(item)

                column += 1
                If column >= animeMatriz.GetLength(1) Then
                    row += 1
                    column = 0
                End If
            Next

            MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading data: " & ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class
