Friend Class Book
    Protected _volume As Integer

    Public Property Volume As Integer
        Get
            Return _volume
        End Get
        Set(value As Integer)
            _volume = value
        End Set
    End Property

    Protected _editorial As String

    Public Property Editorial As String
        Get
            Return _editorial
        End Get
        Set(value As String)
            _editorial = value
        End Set
    End Property

    Protected _price As Double

    'PROPIEDAD DE SOLO ESCRITURA
    Public Property Price As Double
        Get
            Return _price
        End Get
        Set(value As Double)
            _price = value
        End Set
    End Property

    Public Sub New()
        _volume = 0
        _editorial = ""
        _price = 0
    End Sub

    Public Sub New(chaptersnumber As Integer, editorial As String, price As Double)
        _volume = chaptersnumber
        _editorial = editorial
        _price = price
    End Sub

    'METODO QUE RECIBE Y REGRESA
    Public Shared Function GetCollectionCost(mangas As Manga()) As Double
        Dim sumPrice As Double = 0
        For Each manga As Manga In mangas
            If manga IsNot Nothing Then
                sumPrice += manga.price
            End If
        Next
        Return Math.Round(sumPrice, 2)
    End Function
End Class
