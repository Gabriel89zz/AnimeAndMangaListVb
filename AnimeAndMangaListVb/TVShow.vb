Friend Class TVShow
    Protected _productionStudio As String
    Public Property ProductionStudio As String
        Get
            Return _productionStudio
        End Get
        Set(value As String)
            _productionStudio = value
        End Set
    End Property

    Protected _numberofSeasons As Integer
    Public Property NumberOfSeasons As Integer
        Get
            Return _numberofSeasons
        End Get
        Set(value As Integer)
            _numberofSeasons = value
        End Set
    End Property

    Protected _platform As String
    Public Property Platform As String
        Get
            Return _platform
        End Get
        Set(value As String)
            _platform = value
        End Set
    End Property

    Public Sub New()
        _productionStudio = ""
        _numberofSeasons = 0
        _platform = ""
    End Sub

    Public Sub New(productionstudio As String, numberofseasons As Integer, platform As String)
        _productionStudio = productionstudio
        _numberofSeasons = numberofseasons
        _platform = platform
    End Sub

    'METODO QUE RECIBE PERO NO REGRESA
    Public Shared Sub CalulateCostSubscription(animes As Anime(,))
        Dim platformCosts As Dictionary(Of String, Double) = New Dictionary(Of String, Double)()

        For row = 0 To animes.GetLength(0) - 1
            For column = 0 To animes.GetLength(1) - 1
                Dim anime As Anime = animes(row, column)

                If anime IsNot Nothing Then
                    Dim platform As String = anime.Platform
                    Dim cost As Double = 0

                    Select Case platform
                        Case "Crunchyroll"
                            cost = 145
                        Case "Netflix"
                            cost = 219
                        Case "Prime Video"
                            cost = 99
                        Case "Disney Plus"
                            cost = 179
                        Case Else
                            Continue For
                    End Select
                    If Not platformCosts.ContainsKey(platform) Then
                        platformCosts.Add(platform, cost)
                    End If
                End If
            Next
        Next
        Dim sumSubs As Double = 0
        For Each cost In platformCosts.Values
            sumSubs += cost
        Next

        MessageBox.Show("Your expense per month of subscriptions is: " & sumSubs.ToString() & " MXN", "Total Cost of Subscriptions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
