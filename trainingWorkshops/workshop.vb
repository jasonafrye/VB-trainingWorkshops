'Program Name:  trainingWorkshops
'Developer:     Jason A. Frye
'Date:          9/6/11
'Purpose:       This program will allow the user to view and edit available corporate workshops

Option Explicit On
Option Strict On
Imports System.IO
Imports System.IO.File
Imports System.Convert


Public Class workshop
    Public Property Title As String
    Public Property Days As Integer
    Public Property Cost As Double
    Public Property Category As CategoryType
    Public Shared CategoryNames() As String = {"Application Development", "Databases", "Networking", "System Administration"}
    Private Shared mWorkshopList As New Collection

    Enum CategoryType
        ApplicationDevelopment
        Databases
        Networking
        SystemAdministration
    End Enum

    Public Shared Function WS_toString(ByVal wShop As workshop) As String
	'accepts instance of workshop class and converts attributes into concatenated string and returns value to caller

        Dim wShopToString As String
        'set category name to coincide with category type
        Dim strCategory As String = CategoryNames(wShop.Category)

        'concatenate into a string
        wShopToString = "Name: " + wShop.Title + " Category: " + strCategory + " Days: " + wShop.Days.ToString + " Cost: " + wShop.Cost.ToString("C")

        'return string value to caller
        Return wShopToString


    End Function

    Public Shared Sub LoadWorkshops(ByVal strFile As String)
	'Accepts filepath from frmMain and opens a streamreader to begin reading  textfile, 
	'as each line is read, it is broken into an array and assigned to a new instance of the workshop class. 
	'That instance is then added to the collection, converted into a string value, 
	'and sent to frmMain to be added to lstWorkshops

        Try
            'open text file and read first line
            Dim objreader As New StreamReader(strFile)
            Dim strRec As String = objreader.ReadLine
            Dim strOut As String
            Dim chrDelim As Char = ToChar("\")
            Dim strWorkshops() As String

            'loop to retrieve all data from the text tile. 
            While Not objreader.EndOfStream
                strRec = objreader.ReadLine
                'create new instance of workshop
                Dim wShop As New workshop
                'split the line into the appropriate attributes
                strWorkshops = strRec.Split(chrDelim)
                With wShop
                    .Title = strWorkshops(3)
                    .Category = CType(strWorkshops(0), CategoryType)
                    .Days = ToInt32(strWorkshops(1))
                    .Cost = ToDouble(strWorkshops(2))
                End With
                'add instance of workshop to the collection
                mWorkshopList.Add(wShop)

                'send instanced object to convert to string 
                strOut = WS_toString(wShop)

                'send string value to main form to be placed in a list box. 
                frmMain.Populate(strOut)

            End While


        Catch
            Throw New System.Exception("Incorrect Source File")
        End Try

    End Sub

    Public Shared Sub Index(ByVal intSelection As Integer)
	'Accepts the selected index of lstWorkshops, finds the corresponding object from the collection, 
	'and forwards both to frmDetail to be viewed in detail

        Dim wshopOut As workshop
        'copy data from specified workshop object in collection
        wshopOut = CType(mWorkshopList(intSelection + 1), workshop)

        'send new instance to frmDetail to be edited
        Call frmDetail.EditDetails(wshopOut, intSelection)


    End Sub

    Public Shared Sub AdjustCollection(ByVal wShopIn As workshop, ByVal intSelection As Integer)
	'Accepts the new workshop object and selected index of lstWorkShops. 
	'This method then removes the old workshop from the collection and adds the new one. 

        Dim strOut As String
        'remove old object from list
        mWorkshopList.Remove(intSelection + 1)
        'add new object to replace it
        mWorkshopList.Add(wShopIn)
        'send new object to be concatenated into a string
        strOut = WS_toString(wShopIn)
        'send string valute to main form to be replaced in the listbox
        frmMain.AdjustItem(strOut, intSelection)

    End Sub

End Class
