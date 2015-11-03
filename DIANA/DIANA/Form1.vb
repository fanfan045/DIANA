Imports System.Speech.Recognition
Imports System.Speech.Recognition.SrgsGrammar
Imports System.Runtime.InteropServices 'For Monitor Command
Imports System.IO
Imports System.Reflection

Public Class Form1
    'This object represents the Speech recognition engine
    Private recognizer As SpeechRecognizer
    Dim QuestionEvent As String
    Dim Jarvis = CreateObject("Sapi.spvoice")

    Public Sub New()

        InitializeComponent() ' This call is required by the Windows Form Designer.

        recognizer = New SpeechRecognizer() ' Add any initialization after the InitializeComponent() call.

        AddHandler recognizer.SpeechDetected, AddressOf recognizer_SpeechDetected 'this event is raised when the user begins to speak

        AddHandler recognizer.SpeechRecognitionRejected, AddressOf recognizer_SpeechRecognitionRejected 'this is raised when spoken words are not recognized as compliant to our grammar rules

        AddHandler recognizer.SpeechRecognized, AddressOf recognizer_SpeechRecognized 'this is raised when the application correctly recognizes spoken words

        Dim grammar As New GrammarBuilder()
        grammar.Append(New Choices(System.IO.File.ReadAllLines("C:\Users\Mat\Documents\Visual Studio 2015\Projects\DIANA\DIANA\Resources\Commands.txt")))

        recognizer.LoadGrammar(New Grammar(grammar))

    End Sub

    Private Sub recognizer_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        Dim Random As New Random
        Dim Number As Integer = Random.Next(1, 10)
        Select Case e.Result.Text.ToUpper

            'GREETINGS
            Case Is = "HELLO JARVIS", "HELLO"
                Jarvis.Speak("Hello sir")
            Case Is = "GOODBYE JARVIS", "GOODBYE", "GO TO SLEEP JARVIS", "GO TO SLEEP"
                Jarvis.Speak("Until next time")
                Me.Close()

            'STATUS
            Case Is = "WHAT TIME IS IT"
                Jarvis.Speak(Format(Now, "Short Time"))

            Case Is = "WHAT DAY IS IT"
                Jarvis.Speak(Format(Now, "Long Date"))

            Case Is = "HOWS THE WEATHER"
                Jarvis.Speak("Searching for local weather")
                System.Diagnostics.Process.Start("https://www.google.com/webhp?sourceid=chrome-instant&ion=1&ie=UTF-8#output=search&sclient=psy-ab&q=weather&oq=&gs_l=&pbx=1&bav=on.2,or.r_cp.r_qf.&bvm=bv.47008514,d.eWU&fp=6c7f8a5fed4db490&biw=1366&bih=643&ion=1&pf=p&pdl=300")

            'SHELL COMMANDS
            Case Is = "RUN ITUNES"
                Shell("C:\Program Files (x86)\iTunes\iTunes.exe")
                Jarvis.speak("I'm in the mood for a bit of music actually")

            'WEBSITES
            Case Is = "RUN FACEBOOK"
                System.Diagnostics.Process.Start("http://www.facebook.com")
            Case Is = "RUN YAHOO"
                System.Diagnostics.Process.Start("http://www.yahoo.com")
            Case Is = "RUN PANDORA"
                System.Diagnostics.Process.Start("http://www.pandora.com")
            Case Is = "RUN NOSTEAM"
                System.Diagnostics.Process.Start("http://www.nosteam.ro")
            Case Is = "RUN YOUTUBE"
                System.Diagnostics.Process.Start("http://www.youtube.com")

            'MISC
            Case Is = "SHOW COMMANDS"
                lstboxCommands.Visible = True
                Jarvis.speak("Here we are")

            Case Is = "HIDE COMMANDS"
                lstboxCommands.Visible = False
                Jarvis.speak("Very well")

            Case Is = "OUT OF THE WAY JARVIS", "OUT OF THE WAY"
                Select Case Number
                    Case Is < 6
                        Jarvis.speak("My apologies sir")
                    Case Is > 5
                        Jarvis.speak("Right away")
                End Select
                Me.WindowState = FormWindowState.Minimized

            Case Is = "COME BACK JARVIS", "COME BACK"
                Me.WindowState = FormWindowState.Normal
                Jarvis.speak("Here I am")

            Case Is = "OPEN DISK DRIVE"
                Dim oWMP = CreateObject("WMPlayer.OCX.7")
                Dim CDROM = oWMP.cdromCollection
                If CDROM.Count = 2 Then
                    CDROM.Item(1).Eject()
                    Jarvis.speak("Its now open")
                End If

            Case Is = "MONITOR OFF"
                Jarvis.Speak("I'll just close my eyes for a minute")
                SendMessage(Me.Handle.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, 2)

            Case Is = "SHUTDOWN"
                QuestionEvent = "Shutdown"
                Timer1.Enabled = True
                lblTimer.Visible = True

            Case Is = "RESTART"
                QuestionEvent = "Restart"
                Timer1.Enabled = True
                lblTimer.Visible = True

            Case Is = "LOG OFF"
                QuestionEvent = "Log Off"
                Timer1.Enabled = True
                lblTimer.Visible = True

            Case Is = "ABORT"
                Timer1.Enabled = False
                lblTimer.Visible = False
                QuestionEvent = String.Empty

            Case Is = "SPEED UP"
                If Timer1.Interval = 1 Then
                    Jarvis.Speak("Performing at maximum capacity")
                Else : Timer1.Interval = Timer1.Interval / 10
                End If

            Case Is = "SLOW DOWN"
                If Timer1.Interval = 1000 Then
                    Jarvis.Speak("If it were any slower it would be standing still")
                Else : Timer1.Interval = Timer1.Interval * 10
                End If

            'SOCIAL
            Case Is = "JARVIS"
                Jarvis.speak("Yes?")

            Case Is = "GOOD", "IM GOOD"
                Select Case QuestionEvent
                    Case Is = "Particularly well"
                        Jarvis.speak("Glad to hear it")
                    Case Is = "I'm good"
                        Jarvis.speak("Of course")
                    Case Is = "And you"
                        Jarvis.speak("Good")
                End Select

            Case Is = "HOW ARE YOU", "HOW ARE YOU DOING", "HOW ARE YOU TODAY", "HOWS LIFE"
                Select Case Number
                    Case Is = 1, 2
                        Jarvis.speak("Good as always. Thanks for asking")
                    Case Is = 3, 4
                        Jarvis.speak("I'm doing particularly well actually. How are you?")
                        QuestionEvent = "Particularly well"
                    Case Is = 5, 6
                        Jarvis.speak("I'm good. How about you sir?")
                        QuestionEvent = "I'm good"
                    Case Else : Jarvis.speak("Couldn't be better. And you?")
                        QuestionEvent = "And you"
                End Select

        End Select

    End Sub

    'LABEL DETECT / REJECT
    Private Sub recognizer_SpeechDetected(ByVal sender As Object, ByVal e As SpeechDetectedEventArgs)

        Label1.ForeColor = Color.Aqua : Label1.BackColor = Color.Transparent : Label1.Text = "Speech engine has detected that you spoke something"
    End Sub
    Private Sub recognizer_SpeechRecognitionRejected(ByVal sender As Object, ByVal e As SpeechRecognitionRejectedEventArgs)

        Label1.ForeColor = Color.Red : Label1.BackColor = Color.Transparent : Label1.Text = ("Sorry, but the phrase could not be recognized")

    End Sub

    'LOAD COMMANDS IN LIST BOX
    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Commands() As String = System.IO.File.ReadAllLines("C:\Users\Mat\Documents\Visual Studio 2015\Projects\DIANA\DIANA\Resources\Commands.txt")
        For i As Integer = 0 To Commands.Count - 1
            lstboxCommands.Items.Add(Commands(i))
        Next
    End Sub

    'HIDES COMMANDS LIST BOX
    Private Sub lstboxCommands_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstboxCommands.SelectedIndexChanged
        lstboxCommands.Visible = False
    End Sub

    'FOR MONITOR COMMAND
    Public WM_SYSCOMMAND As Integer = &H112
    Public SC_MONITORPOWER As Integer = &HF170
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As Integer, ByVal hMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTimer.Text = FormatNumber(Val(lblTimer.Text) - Val(0.01), 2)
        If lblTimer.Text = 0 Then
            ShutdownProcedure()
            Timer1.Enabled = False
            lblTimer.Visible = False
        End If
    End Sub

    Sub ShutdownProcedure()
        If QuestionEvent = "Shutdown" Then
            System.Diagnostics.Process.Start("shutdown", "-s")
        ElseIf QuestionEvent = "Restart" Then
            System.Diagnostics.Process.Start("shutdown", "-r")
        ElseIf QuestionEvent = "Log Off" Then
            System.Diagnostics.Process.Start("shutdown", "-l")
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
