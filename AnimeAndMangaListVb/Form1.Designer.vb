<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtTitle = New TextBox()
        txtAuthor = New TextBox()
        txtChapters = New TextBox()
        btnSaveManga = New Button()
        lblTitle = New Label()
        lblAuthor = New Label()
        lblDate = New Label()
        lblGenre = New Label()
        lblEditorial = New Label()
        lblChapters = New Label()
        lblPrice = New Label()
        txtPrice = New TextBox()
        lblRating = New Label()
        btnCalculateCost = New Button()
        btnAddManga = New Button()
        btnAddAnime = New Button()
        lstvData = New ListView()
        dtpDate = New DateTimePicker()
        nudRating = New NumericUpDown()
        btnSaveAnime = New Button()
        btnDeleteManga = New Button()
        cbEditorial = New ComboBox()
        btnExport = New Button()
        cbGenre = New ComboBox()
        txtReview = New TextBox()
        lblAddReview = New Label()
        btnSaveReview = New Button()
        btnLoadData = New Button()
        CType(nudRating, ComponentModel.ISupportInitialize).BeginInit()
        ' 
        ' txtTitle
        ' 
        txtTitle.Font = New Font("Microsoft Tai Le", 11.0F)
        txtTitle.Location = New Point(197, 83)
        txtTitle.Margin = New Padding(4)
        txtTitle.Name = "txtTitle"
        txtTitle.Size = New Size(312, 26)
        txtTitle.TabIndex = 0
        ' 
        ' txtAuthor
        ' 
        txtAuthor.Font = New Font("Microsoft Tai Le", 11.0F)
        txtAuthor.Location = New Point(197, 138)
        txtAuthor.Margin = New Padding(4)
        txtAuthor.Name = "txtAuthor"
        txtAuthor.Size = New Size(312, 26)
        txtAuthor.TabIndex = 2
        ' 
        ' txtChapters
        ' 
        txtChapters.Font = New Font("Microsoft Tai Le", 11.0F)
        txtChapters.Location = New Point(705, 77)
        txtChapters.Margin = New Padding(4)
        txtChapters.Name = "txtChapters"
        txtChapters.Size = New Size(121, 26)
        txtChapters.TabIndex = 5
        ' 
        ' btnSaveManga
        ' 
        btnSaveManga.BackColor = SystemColors.ActiveCaptionText
        btnSaveManga.FlatAppearance.BorderColor = SystemColors.WindowText
        btnSaveManga.FlatAppearance.BorderSize = 0
        btnSaveManga.FlatAppearance.MouseOverBackColor = Color.DarkOrchid
        btnSaveManga.FlatStyle = FlatStyle.Flat
        btnSaveManga.ForeColor = SystemColors.ControlLightLight
        btnSaveManga.Location = New Point(1086, 77)
        btnSaveManga.Margin = New Padding(4)
        btnSaveManga.Name = "btnSaveManga"
        btnSaveManga.Size = New Size(97, 44)
        btnSaveManga.TabIndex = 7
        btnSaveManga.Text = "Save"
        btnSaveManga.UseVisualStyleBackColor = False
        AddHandler btnSaveManga.Click, AddressOf btnSaveManga_Click
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        lblTitle.Location = New Point(40, 83)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(44, 19)
        lblTitle.TabIndex = 9
        lblTitle.Text = "Title:"
        ' 
        ' lblAuthor
        ' 
        lblAuthor.AutoSize = True
        lblAuthor.Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        lblAuthor.Location = New Point(40, 140)
        lblAuthor.Margin = New Padding(4, 0, 4, 0)
        lblAuthor.Name = "lblAuthor"
        lblAuthor.Size = New Size(63, 19)
        lblAuthor.TabIndex = 10
        lblAuthor.Text = "Author:"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        lblDate.Location = New Point(40, 254)
        lblDate.Margin = New Padding(4, 0, 4, 0)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(129, 19)
        lblDate.TabIndex = 12
        lblDate.Text = "Acquisition Date:"
        ' 
        ' lblGenre
        ' 
        lblGenre.AutoSize = True
        lblGenre.Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        lblGenre.Location = New Point(40, 197)
        lblGenre.Margin = New Padding(4, 0, 4, 0)
        lblGenre.Name = "lblGenre"
        lblGenre.Size = New Size(55, 19)
        lblGenre.TabIndex = 11
        lblGenre.Text = "Genre:"
        ' 
        ' lblEditorial
        ' 
        lblEditorial.AutoSize = True
        lblEditorial.Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        lblEditorial.Location = New Point(547, 136)
        lblEditorial.Margin = New Padding(4, 0, 4, 0)
        lblEditorial.Name = "lblEditorial"
        lblEditorial.Size = New Size(71, 19)
        lblEditorial.TabIndex = 14
        lblEditorial.Text = "Editorial:"
        ' 
        ' lblChapters
        ' 
        lblChapters.AutoSize = True
        lblChapters.Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        lblChapters.Location = New Point(547, 82)
        lblChapters.Margin = New Padding(4, 0, 4, 0)
        lblChapters.Name = "lblChapters"
        lblChapters.Size = New Size(67, 19)
        lblChapters.TabIndex = 13
        lblChapters.Text = "Volume:"
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        lblPrice.Location = New Point(547, 190)
        lblPrice.Margin = New Padding(4, 0, 4, 0)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(47, 19)
        lblPrice.TabIndex = 17
        lblPrice.Text = "Price:"
        ' 
        ' txtPrice
        ' 
        txtPrice.Font = New Font("Microsoft Tai Le", 11.0F)
        txtPrice.Location = New Point(705, 188)
        txtPrice.Margin = New Padding(4)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(312, 26)
        txtPrice.TabIndex = 16
        ' 
        ' lblRating
        ' 
        lblRating.AutoSize = True
        lblRating.Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        lblRating.Location = New Point(547, 244)
        lblRating.Margin = New Padding(4, 0, 4, 0)
        lblRating.Name = "lblRating"
        lblRating.Size = New Size(59, 19)
        lblRating.TabIndex = 19
        lblRating.Text = "Rating:"
        ' 
        ' btnCalculateCost
        ' 
        btnCalculateCost.BackColor = SystemColors.ActiveCaptionText
        btnCalculateCost.Cursor = Cursors.Hand
        btnCalculateCost.FlatAppearance.BorderSize = 0
        btnCalculateCost.FlatAppearance.MouseOverBackColor = Color.DarkOrchid
        btnCalculateCost.FlatStyle = FlatStyle.Flat
        btnCalculateCost.Font = New Font("Microsoft Tai Le", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnCalculateCost.ForeColor = SystemColors.ControlLightLight
        btnCalculateCost.Location = New Point(1086, 216)
        btnCalculateCost.Margin = New Padding(4)
        btnCalculateCost.Name = "btnCalculateCost"
        btnCalculateCost.Size = New Size(97, 48)
        btnCalculateCost.TabIndex = 20
        btnCalculateCost.Text = "Calculate Cost"
        btnCalculateCost.UseVisualStyleBackColor = False
        AddHandler btnCalculateCost.Click, AddressOf btnCalculateCost_Click
        ' 
        ' btnAddManga
        ' 
        btnAddManga.BackColor = Color.DarkOrchid
        btnAddManga.Cursor = Cursors.Hand
        btnAddManga.FlatAppearance.BorderSize = 0
        btnAddManga.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAddManga.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaptionText
        btnAddManga.FlatStyle = FlatStyle.Flat
        btnAddManga.Font = New Font("Nirmala UI", 12.0F, FontStyle.Bold)
        btnAddManga.ForeColor = SystemColors.ButtonFace
        btnAddManga.Location = New Point(317, 14)
        btnAddManga.Margin = New Padding(4)
        btnAddManga.Name = "btnAddManga"
        btnAddManga.Size = New Size(117, 44)
        btnAddManga.TabIndex = 21
        btnAddManga.Text = "Add Manga"
        btnAddManga.UseVisualStyleBackColor = False
        AddHandler btnAddManga.Click, AddressOf btnAddManga_Click
        ' 
        ' btnAddAnime
        ' 
        btnAddAnime.BackColor = Color.DarkOrchid
        btnAddAnime.Cursor = Cursors.Hand
        btnAddAnime.FlatAppearance.BorderSize = 0
        btnAddAnime.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAddAnime.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaptionText
        btnAddAnime.FlatStyle = FlatStyle.Flat
        btnAddAnime.Font = New Font("Nirmala UI", 12.0F, FontStyle.Bold)
        btnAddAnime.ForeColor = SystemColors.ButtonFace
        btnAddAnime.Location = New Point(809, 14)
        btnAddAnime.Margin = New Padding(4)
        btnAddAnime.Name = "btnAddAnime"
        btnAddAnime.Size = New Size(117, 44)
        btnAddAnime.TabIndex = 22
        btnAddAnime.Text = "Add Anime"
        btnAddAnime.UseVisualStyleBackColor = False
        AddHandler btnAddAnime.Click, AddressOf btnAddAnime_Click
        ' 
        ' lstvData
        ' 
        lstvData.FullRowSelect = True
        lstvData.Location = New Point(364, 291)
        lstvData.Margin = New Padding(4, 3, 4, 3)
        lstvData.Name = "lstvData"
        lstvData.Size = New Size(856, 267)
        lstvData.TabIndex = 23
        lstvData.UseCompatibleStateImageBehavior = False
        ' 
        ' dtpDate
        ' 
        dtpDate.Font = New Font("Microsoft Tai Le", 11.0F)
        dtpDate.Format = DateTimePickerFormat.[Short]
        dtpDate.Location = New Point(197, 248)
        dtpDate.Margin = New Padding(4, 3, 4, 3)
        dtpDate.Name = "dtpDate"
        dtpDate.Size = New Size(224, 26)
        dtpDate.TabIndex = 26
        ' 
        ' nudRating
        ' 
        nudRating.Font = New Font("Microsoft Tai Le", 11.0F)
        nudRating.Location = New Point(705, 242)
        nudRating.Margin = New Padding(4, 3, 4, 3)
        nudRating.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        nudRating.Name = "nudRating"
        nudRating.Size = New Size(45, 26)
        nudRating.TabIndex = 27
        ' 
        ' btnSaveAnime
        ' 
        btnSaveAnime.BackColor = SystemColors.ActiveCaptionText
        btnSaveAnime.Cursor = Cursors.Hand
        btnSaveAnime.FlatAppearance.BorderColor = SystemColors.WindowFrame
        btnSaveAnime.FlatAppearance.BorderSize = 0
        btnSaveAnime.FlatAppearance.MouseOverBackColor = Color.DarkOrchid
        btnSaveAnime.FlatStyle = FlatStyle.Flat
        btnSaveAnime.ForeColor = SystemColors.ControlLightLight
        btnSaveAnime.Location = New Point(1086, 77)
        btnSaveAnime.Margin = New Padding(4)
        btnSaveAnime.Name = "btnSaveAnime"
        btnSaveAnime.Size = New Size(97, 44)
        btnSaveAnime.TabIndex = 28
        btnSaveAnime.Text = "Save"
        btnSaveAnime.UseVisualStyleBackColor = False
        AddHandler btnSaveAnime.Click, AddressOf btnSaveAnime_Click
        ' 
        ' btnDeleteManga
        ' 
        btnDeleteManga.BackColor = SystemColors.ActiveCaptionText
        btnDeleteManga.Cursor = Cursors.Hand
        btnDeleteManga.FlatAppearance.BorderSize = 0
        btnDeleteManga.FlatAppearance.MouseOverBackColor = Color.DarkOrchid
        btnDeleteManga.FlatStyle = FlatStyle.Flat
        btnDeleteManga.ForeColor = SystemColors.ControlLightLight
        btnDeleteManga.Location = New Point(1086, 149)
        btnDeleteManga.Margin = New Padding(4, 3, 4, 3)
        btnDeleteManga.Name = "btnDeleteManga"
        btnDeleteManga.Size = New Size(97, 39)
        btnDeleteManga.TabIndex = 29
        btnDeleteManga.Text = "Delete"
        btnDeleteManga.UseVisualStyleBackColor = False
        AddHandler btnDeleteManga.Click, AddressOf btnDeleteManga_Click
        ' 
        ' cbEditorial
        ' 
        cbEditorial.Font = New Font("Microsoft Tai Le", 11.0F)
        cbEditorial.FormattingEnabled = True
        cbEditorial.Items.AddRange(New Object() {"Panini", "Ivrea", "Norma", "Kamite"})
        cbEditorial.Location = New Point(705, 132)
        cbEditorial.Margin = New Padding(3, 4, 3, 4)
        cbEditorial.Name = "cbEditorial"
        cbEditorial.Size = New Size(121, 27)
        cbEditorial.TabIndex = 30
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = SystemColors.ActiveCaptionText
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatAppearance.MouseOverBackColor = Color.DarkOrchid
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.ForeColor = SystemColors.ButtonHighlight
        btnExport.Location = New Point(1123, 570)
        btnExport.Margin = New Padding(3, 4, 3, 4)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(86, 35)
        btnExport.TabIndex = 32
        btnExport.Text = "Export To"
        btnExport.UseVisualStyleBackColor = False
        AddHandler btnExport.Click, AddressOf btnExport_Click
        ' 
        ' cbGenre
        ' 
        cbGenre.Font = New Font("Microsoft Tai Le", 11.0F)
        cbGenre.FormattingEnabled = True
        cbGenre.Items.AddRange(New Object() {"Shonen", "Seinen", "Romcom", "Shojo", "Science fiction", "Comedy"})
        cbGenre.Location = New Point(197, 193)
        cbGenre.Margin = New Padding(3, 4, 3, 4)
        cbGenre.Name = "cbGenre"
        cbGenre.Size = New Size(193, 27)
        cbGenre.TabIndex = 33
        ' 
        ' txtReview
        ' 
        txtReview.Font = New Font("Microsoft Tai Le", 10.0F, FontStyle.Bold)
        txtReview.Location = New Point(21, 356)
        txtReview.Margin = New Padding(3, 4, 3, 4)
        txtReview.Multiline = True
        txtReview.Name = "txtReview"
        txtReview.Size = New Size(317, 188)
        txtReview.TabIndex = 34
        txtReview.Text = "Title of manga:" & vbCrLf & vbCrLf & "Review:"
        ' 
        ' lblAddReview
        ' 
        lblAddReview.AutoSize = True
        lblAddReview.Location = New Point(21, 333)
        lblAddReview.Name = "lblAddReview"
        lblAddReview.Size = New Size(100, 19)
        lblAddReview.TabIndex = 35
        lblAddReview.Text = "Add a review"
        ' 
        ' btnSaveReview
        ' 
        btnSaveReview.BackColor = SystemColors.ActiveCaptionText
        btnSaveReview.Cursor = Cursors.Hand
        btnSaveReview.FlatAppearance.BorderSize = 0
        btnSaveReview.FlatAppearance.MouseOverBackColor = Color.DarkOrchid
        btnSaveReview.FlatStyle = FlatStyle.Flat
        btnSaveReview.ForeColor = SystemColors.Window
        btnSaveReview.Location = New Point(21, 561)
        btnSaveReview.Margin = New Padding(3, 4, 3, 4)
        btnSaveReview.Name = "btnSaveReview"
        btnSaveReview.Size = New Size(75, 32)
        btnSaveReview.TabIndex = 36
        btnSaveReview.Text = "Save"
        btnSaveReview.UseVisualStyleBackColor = False
        AddHandler btnSaveReview.Click, AddressOf btnSaveReview_Click
        ' 
        ' btnLoadData
        ' 
        btnLoadData.BackColor = SystemColors.ActiveCaptionText
        btnLoadData.BackgroundImageLayout = ImageLayout.Zoom
        btnLoadData.Cursor = Cursors.Hand
        btnLoadData.FlatAppearance.BorderSize = 0
        btnLoadData.FlatAppearance.MouseOverBackColor = Color.DarkOrchid
        btnLoadData.FlatStyle = FlatStyle.Flat
        btnLoadData.ForeColor = SystemColors.ButtonHighlight
        btnLoadData.Location = New Point(12, 14)
        btnLoadData.Margin = New Padding(3, 4, 3, 4)
        btnLoadData.Name = "btnLoadData"
        btnLoadData.Size = New Size(104, 44)
        btnLoadData.TabIndex = 37
        btnLoadData.Text = "Load data"
        btnLoadData.UseVisualStyleBackColor = False
        AddHandler btnLoadData.Click, AddressOf btnLoadData_Click
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9.0F, 19.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLightLight
        ClientSize = New Size(1233, 619)
        Controls.Add(btnLoadData)
        Controls.Add(btnSaveReview)
        Controls.Add(lblAddReview)
        Controls.Add(txtReview)
        Controls.Add(cbGenre)
        Controls.Add(btnExport)
        Controls.Add(cbEditorial)
        Controls.Add(btnDeleteManga)
        Controls.Add(btnSaveAnime)
        Controls.Add(nudRating)
        Controls.Add(dtpDate)
        Controls.Add(lstvData)
        Controls.Add(btnAddAnime)
        Controls.Add(btnAddManga)
        Controls.Add(btnCalculateCost)
        Controls.Add(lblRating)
        Controls.Add(lblPrice)
        Controls.Add(txtPrice)
        Controls.Add(lblEditorial)
        Controls.Add(lblChapters)
        Controls.Add(lblDate)
        Controls.Add(lblGenre)
        Controls.Add(lblAuthor)
        Controls.Add(lblTitle)
        Controls.Add(btnSaveManga)
        Controls.Add(txtChapters)
        Controls.Add(txtAuthor)
        Controls.Add(txtTitle)
        Font = New Font("Microsoft Tai Le", 11.0F, FontStyle.Bold)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        CType(nudRating, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnAddAnime As Button
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents txtChapters As TextBox
    Friend WithEvents btnSaveManga As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblAuthor As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblGenre As Label
    Friend WithEvents lblEditorial As Label
    Friend WithEvents lblChapters As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblRating As Label
    Friend WithEvents btnCalculateCost As Button
    Friend WithEvents btnAddManga As Button
    Friend WithEvents lstvData As ListView
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents nudRating As NumericUpDown
    Friend WithEvents btnSaveAnime As Button
    Friend WithEvents btnDeleteManga As Button
    Friend WithEvents cbEditorial As ComboBox
    Friend WithEvents btnExport As Button
    Friend WithEvents cbGenre As ComboBox
    Friend WithEvents txtReview As TextBox
    Friend WithEvents lblAddReview As Label
    Friend WithEvents btnSaveReview As Button
    Friend WithEvents btnLoadData As Button
End Class
