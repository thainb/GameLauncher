﻿Imports System.IO

Public Class AddNewGameForm

    Public currentIcon As Image = Nothing

    Sub resetForm()
        gameNameTextBox.Text = Nothing
        commandLineTextBox.Text = Nothing
        normalGameRadio.Checked = True
        gamePathTextBox.Text = Nothing
        usesLauncherCheckBox.Checked = False
        launcherPathTextBox.Text = Nothing
        steamAppIDTextBox.Text = Nothing
        specifySteamExeCheckBox.Checked = False
        steamExePathTextBox.Text = Nothing
        getFromExeRadio.Checked = True
        gameIconPreviewBox.BackgroundImage = Nothing
        customIconPathTextBox.Text = Nothing
        keepCurrentIconRadio.Enabled = False
        currentIcon = Nothing
    End Sub

    Sub setHelp(ByVal helpText As String)
        helpTextLabel.ForeColor = Color.Black
        helpTextLabel.Text = helpText
    End Sub

    Sub resetHelp()
        helpTextLabel.ForeColor = Color.DarkGray
        helpTextLabel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormDefaultHelpText")
    End Sub

    Private Sub AddNewGameForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub AddNewGameForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim controls As Control() = {gameNameTextBox, commandLineTextBox, getFromExeRadio, getFromOtherFileRadio, iconBrowseButton, gameIconPreviewBox, _
                                     normalGameRadio, pathBrowseButton, usesLauncherCheckBox, launcherBrowseButton, steamGameRadio, steamAppIDTextBox, _
                                     okayButton, cancelAddGameButton, specifySteamExeCheckBox}

        For Each helpControl As Control In controls
            AddHandler helpControl.MouseLeave, AddressOf resetHelp
        Next

        ' Multi-language stuff
        Me.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormTitleBar")
        GameInfoGroupBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGameInfoGroupBox")
        GameNameLabel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGameNameLabel")
        CmdArgsLabel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormCmdArgsLabel")
        GamePathsGroupBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGamePathsGroupBox")
        normalGameRadio.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormNormalGameRadio")
        usesLauncherCheckBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormUsesLauncherCheckBox")
        steamGameRadio.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormSteamGameRadio")
        specifySteamExeCheckBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormSpecifySteamExeCheckBox")
        IconGroupBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormIconGroupBox")
        getFromExeRadio.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGetFromExeRadio")
        getFromOtherFileRadio.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGetFromOtherFileRadio")
        keepCurrentIconRadio.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormKeepIconRadio")
        HelpGroupBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormHelpGroupBox")
        okayButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormOKButton")
        cancelAddGameButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormCancelButton")
        helpTextLabel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormDefaultHelpText")

        'Browse buttons
        pathBrowseButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormBrowseButtons")
        launcherBrowseButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormBrowseButtons")
        steamExeBrowseButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormBrowseButtons")
        iconBrowseButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormBrowseButtons")

    End Sub

    Private Sub gameNameTextBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles gameNameTextBox.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGameNameHelpText"))
    End Sub

    Private Sub commandLineTextBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles commandLineTextBox.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormCmdArgsHelpText"))
    End Sub

    Private Sub getFromExeRadio_MouseEnter(sender As System.Object, e As System.EventArgs) Handles getFromExeRadio.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGetFromExeHelpText"))
    End Sub

    Private Sub getFromOtherFileRadio_MouseEnter(sender As System.Object, e As System.EventArgs) Handles getFromOtherFileRadio.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGetFromOtherFileHelpText"))
    End Sub

    Private Sub iconBrowseButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles iconBrowseButton.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormCustomIconHelpText"))
    End Sub

    Private Sub normalGameRadio_MouseEnter(sender As System.Object, e As System.EventArgs) Handles normalGameRadio.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormNormalGameHelpText"))
    End Sub

    Private Sub pathBrowseButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles pathBrowseButton.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormBrowseExeHelpText"))
    End Sub

    Private Sub usesLauncherCheckBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles usesLauncherCheckBox.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormUsesLauncherHelpText"))
    End Sub

    Private Sub launcherBrowseButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles launcherBrowseButton.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormLauncherBrowseHelpText"))
    End Sub

    Private Sub steamGameRadio_MouseEnter(sender As System.Object, e As System.EventArgs) Handles steamGameRadio.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormSteamHelpText"))
    End Sub

    Private Sub TextBox1_MouseEnter(sender As System.Object, e As System.EventArgs) Handles steamAppIDTextBox.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormSteamAppIdHelpText"))
    End Sub

    Private Sub cancelAddGameButton_Click(sender As System.Object, e As System.EventArgs) Handles cancelAddGameButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub gameIconPreviewBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles gameIconPreviewBox.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormIconHelpText"))
    End Sub

    Private Sub getFromOtherFileRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles getFromOtherFileRadio.CheckedChanged
        If getFromOtherFileRadio.Checked = True Then
            iconBrowseButton.Enabled = True
            customIconPathTextBox.Enabled = True

            If customIconPathTextBox.Text <> "" Then
                Dim fileName As String = customIconPathTextBox.Text
                Dim sourceBitmap As Bitmap
                Dim extension As String = Path.GetExtension(fileName).ToLower

                Select Case extension
                    Case ".exe"
                        sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                        gameIconPreviewBox.BackgroundImage = sourceBitmap

                        If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                            Exit Sub
                        End If
                    Case Else
                        sourceBitmap = New Bitmap(fileName)
                End Select

                gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
            End If
        End If
    End Sub

    Private Sub normalGameRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles normalGameRadio.CheckedChanged
        If normalGameRadio.Checked = True Then
            gamePathTextBox.Enabled = True
            pathBrowseButton.Enabled = True
            usesLauncherCheckBox.Enabled = True

            If usesLauncherCheckBox.Checked = True Then
                launcherPathTextBox.Enabled = True
                launcherBrowseButton.Enabled = True
            Else
                launcherPathTextBox.Enabled = False
                launcherBrowseButton.Enabled = False
            End If

            steamAppIDTextBox.Enabled = False
            specifySteamExeCheckBox.Enabled = False
            steamExePathTextBox.Enabled = False
            steamExeBrowseButton.Enabled = False
        Else
            gamePathTextBox.Enabled = False
            pathBrowseButton.Enabled = False
            usesLauncherCheckBox.Enabled = False
            launcherPathTextBox.Enabled = False
            launcherBrowseButton.Enabled = False
            steamAppIDTextBox.Enabled = True
            specifySteamExeCheckBox.Enabled = True

            If specifySteamExeCheckBox.Checked = True Then
                steamExePathTextBox.Enabled = True
                steamExeBrowseButton.Enabled = True
            Else
                steamExePathTextBox.Enabled = False
                steamExeBrowseButton.Enabled = False
            End If
        End If
    End Sub

    Private Sub okayButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles okayButton.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormOKHelp"))
    End Sub

    Private Sub cancelAddGameButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles cancelAddGameButton.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormCancelHelpText"))
    End Sub

    Private Sub specifySteamExeCheckBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles specifySteamExeCheckBox.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormSpecifySteamExeHelpText"))
    End Sub

    Private Sub steamExeBrowseButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles steamExeBrowseButton.MouseEnter
        setHelp(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormSteamExeBrowseHelpText"))
    End Sub

    Private Sub usesLauncherCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles usesLauncherCheckBox.CheckedChanged
        If usesLauncherCheckBox.Checked = True Then
            launcherPathTextBox.Enabled = True
            launcherBrowseButton.Enabled = True
        Else
            launcherPathTextBox.Enabled = False
            launcherBrowseButton.Enabled = False
        End If
    End Sub

    Private Sub specifySteamExeCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles specifySteamExeCheckBox.CheckedChanged
        If specifySteamExeCheckBox.Checked = True Then
            steamExePathTextBox.Enabled = True
            steamExeBrowseButton.Enabled = True
        Else
            steamExePathTextBox.Enabled = False
            steamExeBrowseButton.Enabled = False
        End If
    End Sub

    Private Sub pathBrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles pathBrowseButton.Click
        If browseForExeDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            gamePathTextBox.Text = browseForExeDialog.FileName

            If getFromExeRadio.Checked = True Then
                Dim fileName As String = gamePathTextBox.Text
                Dim sourceBitmap As Bitmap
                Dim extension As String = Path.GetExtension(fileName).ToLower

                Select Case extension
                    Case ".exe"
                        sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                        gameIconPreviewBox.BackgroundImage = sourceBitmap

                        If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                            Exit Sub
                        End If
                    Case Else
                        sourceBitmap = New Bitmap(fileName)
                End Select

                gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
            End If

            browseForExeDialog.FileName = Nothing
        End If
    End Sub

    Private Sub launcherBrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles launcherBrowseButton.Click
        If browseForExeDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            launcherPathTextBox.Text = browseForExeDialog.FileName
            browseForExeDialog.FileName = Nothing
        End If
    End Sub

    Private Sub steamExeBrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles steamExeBrowseButton.Click
        If browseForExeDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            steamExePathTextBox.Text = browseForExeDialog.FileName
            browseForExeDialog.FileName = Nothing

            If getFromExeRadio.Checked Then
                Dim fileName As String = steamExePathTextBox.Text
                Dim sourceBitmap As Bitmap
                Dim extension As String = Path.GetExtension(fileName).ToLower

                Select Case extension
                    Case ".exe"
                        sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                        gameIconPreviewBox.BackgroundImage = sourceBitmap

                        If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                            Exit Sub
                        End If
                    Case Else
                        sourceBitmap = New Bitmap(fileName)
                End Select

                gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
            End If
        End If
    End Sub

    Private Sub iconBrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles iconBrowseButton.Click
        If browseForIconDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            customIconPathTextBox.Text = browseForIconDialog.FileName
            browseForIconDialog.FileName = Nothing
            Dim fileName As String = customIconPathTextBox.Text
            Dim sourceBitmap As Bitmap
            Dim extension As String = Path.GetExtension(fileName).ToLower

            Select Case extension
                Case ".exe"
                    sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                    gameIconPreviewBox.BackgroundImage = sourceBitmap

                    If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                        Exit Sub
                    End If
                Case Else
                    sourceBitmap = New Bitmap(fileName)
            End Select

            gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
        End If
    End Sub

    Private Sub okayButton_Click(sender As System.Object, e As System.EventArgs) Handles okayButton.Click
        'Put values in vars
        Dim gameName, cmdArgs, gamePath, launcherPath, steamAppID, steamExePath As String

        gameName = ""
        cmdArgs = ""
        gamePath = ""
        launcherPath = ""
        steamAppID = ""
        steamExePath = ""

        gameName = gameNameTextBox.Text.Trim.Replace("="c, "-"c).Replace("&", "&&")
        cmdArgs = commandLineTextBox.Text.Trim.Replace("=", "|||")

        If normalGameRadio.Checked Then
            gamePath = gamePathTextBox.Text.Trim
        Else
            steamAppID = steamAppIDTextBox.Text.Trim
        End If

        If usesLauncherCheckBox.Checked Then
            launcherPath = launcherPathTextBox.Text.Trim
        End If

        If specifySteamExeCheckBox.Checked Then
            steamExePath = steamExePathTextBox.Text.Trim
        End If

        'Validate the form
        If gameName = "" Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorNoName"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            gameNameTextBox.Focus()
        ElseIf normalGameRadio.Checked And gamePath = "" Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorNoMainPath"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            gamePathTextBox.Focus()
        ElseIf normalGameRadio.Checked And usesLauncherCheckBox.Checked And launcherPath = "" Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorNoLauncherPath"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            launcherPathTextBox.Focus()
        ElseIf steamGameRadio.Checked And steamAppID = "" Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorNoAppId"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            steamAppIDTextBox.Focus()
        ElseIf steamGameRadio.Checked And specifySteamExeCheckBox.Checked And steamExePath = "" Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorNoSteamExePath"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            steamExePathTextBox.Focus()
        ElseIf steamGameRadio.Checked And getFromExeRadio.Checked And specifySteamExeCheckBox.Checked = False Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorNoSteamExePathClickedGetFromExecutable"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf steamGameRadio.Checked And getFromOtherFileRadio.Checked And customIconPathTextBox.Text = "" Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorNoSteamIcon"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            customIconPathTextBox.Focus()
        ElseIf normalGameRadio.Checked And getFromOtherFileRadio.Checked And customIconPathTextBox.Text = "" Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormGetFromOtherFileNoIcon"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            customIconPathTextBox.Focus()
        Else
            'Everything seems to be in order, now check the validity of the specified exes, if any
            If normalGameRadio.Checked And File.Exists(gamePath) = False Then
                MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorMainExeNotFound") & vbNewLine & gamePath, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf normalGameRadio.Checked And usesLauncherCheckBox.Checked And File.Exists(launcherPath) = False Then
                MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorLauncherExeNotFound") & vbNewLine & launcherPath, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf steamGameRadio.Checked And specifySteamExeCheckBox.Checked And File.Exists(steamExePath) = False Then
                MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormErrorSteamExeNotFound") & vbNewLine & steamExePath, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'EXEs exist, all systems are go!
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub AddNewGameForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        AppActivate(Me.Text)
        gameNameTextBox.Focus()
        gameNameTextBox.SelectAll()
    End Sub

    Private Sub keepCurrentIconRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles keepCurrentIconRadio.CheckedChanged
        If keepCurrentIconRadio.Checked Then
            gameIconPreviewBox.BackgroundImage = currentIcon
        End If
    End Sub

    Private Sub getFromExeRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles getFromExeRadio.CheckedChanged
        If getFromExeRadio.Checked = True Then
            iconBrowseButton.Enabled = False
            customIconPathTextBox.Enabled = False

            If normalGameRadio.Checked Then
                If gamePathTextBox.Text <> "" Then
                    Dim fileName As String = gamePathTextBox.Text
                    Dim sourceBitmap As Bitmap
                    Dim extension As String = Path.GetExtension(fileName).ToLower

                    Select Case extension
                        Case ".exe"
                            sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                            gameIconPreviewBox.BackgroundImage = sourceBitmap

                            If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                                Exit Sub
                            End If
                        Case Else
                            sourceBitmap = New Bitmap(fileName)
                    End Select

                    gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
                End If
            ElseIf specifySteamExeCheckBox.Checked = True Then
                If steamExePathTextBox.Text <> "" Then
                    Dim fileName As String = steamExePathTextBox.Text
                    Dim sourceBitmap As Bitmap
                    Dim extension As String = Path.GetExtension(fileName).ToLower

                    Select Case extension
                        Case ".exe"
                            sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                            gameIconPreviewBox.BackgroundImage = sourceBitmap

                            If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                                Exit Sub
                            End If
                        Case Else
                            sourceBitmap = New Bitmap(fileName)
                    End Select

                    gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
                End If
            End If
        End If
    End Sub
End Class