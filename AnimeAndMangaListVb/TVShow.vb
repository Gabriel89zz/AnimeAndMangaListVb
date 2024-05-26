Friend Class TVShow
    Protected productionstudioField As String
    Public Property ProductionStudio As String
        Get
            Return productionstudioField
        End Get
        Set(value As String)
            productionstudioField = value
        End Set
    End Property

    Protected numberofseasonsField As Integer
    Public Property NumberOfSeasons As Integer
        Get
            Return numberofseasonsField
        End Get
        Set(value As Integer)
            numberofseasonsField = value
        End Set
    End Property

    Protected platformField As String
    Public Property Platform As String
        Get
            Return platformField
        End Get
        Set(value As String)
            platformField = value
        End Set
    End Property

    Public Sub New()
        productionstudioField = ""
        numberofseasonsField = 0
        platformField = ""
    End Sub

    Public Sub New(productionstudio As String, numberofseasons As Integer, platform As String)
        productionstudioField = productionstudio
        numberofseasonsField = numberofseasons
        platformField = platform
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
