Friend Class Book
    Protected volumeField As Integer

    Public Property Volume As Integer
        Get
            Return volumeField
        End Get
        Set(value As Integer)
            volumeField = value
        End Set
    End Property

    Protected editorialField As String

    Public Property Editorial As String
        Get
            Return editorialField
        End Get
        Set(value As String)
            editorialField = value
        End Set
    End Property

    Protected priceField As Double

    'PROPIEDAD DE SOLO ESCRITURA
    Public Property Price As Double
        Get
            Return priceField
        End Get
        Set(value As Double)
            priceField = value
        End Set
    End Property

    Public Sub New()
        volumeField = 0
        editorialField = ""
        priceField = 0
    End Sub

    Public Sub New(chaptersnumber As Integer, editorial As String, price As Double)
        volumeField = chaptersnumber
        editorialField = editorial
        priceField = price
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
