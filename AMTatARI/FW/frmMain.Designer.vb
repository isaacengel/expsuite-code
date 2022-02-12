<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        Me.IsInitializing = True
        InitializeComponent()
        Me.IsInitializing = False
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents imlItemList As System.Windows.Forms.ImageList
    Public WithEvents lstStatus As System.Windows.Forms.ListBox
    Public WithEvents tmrStatus As System.Windows.Forms.Timer
    Public WithEvents connectionTimer As System.Windows.Forms.Timer
    Public WithEvents lblWorkDir As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents lblExpType As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents lblRootDir As System.Windows.Forms.Label
    Public WithEvents lblStimOutput As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents tmrExp As System.Windows.Forms.Timer
    Public WithEvents cmdItemBrowse As System.Windows.Forms.Button
    Public WithEvents cmbResult As System.Windows.Forms.ListBox
    Public WithEvents cmdTTShow As System.Windows.Forms.Button
    Public WithEvents cmdItemUndo As System.Windows.Forms.Button
    Public WithEvents cmdItemMoveDown As System.Windows.Forms.Button
    Public WithEvents cmdItemMoveUp As System.Windows.Forms.Button
    Public WithEvents chkExpRun As System.Windows.Forms.CheckBox
    Public WithEvents cmdItemInsert As System.Windows.Forms.Button
    Public WithEvents cmdItemStimulateAll As System.Windows.Forms.Button
    Public WithEvents cmdResultExecute As System.Windows.Forms.Button
    Public WithEvents cmdItemSortList As System.Windows.Forms.Button
    Public WithEvents cmdItemDel As System.Windows.Forms.Button
    Public WithEvents cmdItemShuffleList As System.Windows.Forms.Button
    Public WithEvents cmdItemCreateList As System.Windows.Forms.Button
    Public WithEvents cmdCreateAllStimuli As System.Windows.Forms.Button
    Public WithEvents cmdItemAddRepetition As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdItemLogList As System.Windows.Forms.Button
    Public WithEvents cmdStartExp As System.Windows.Forms.Button
    Public WithEvents cmdItemSet As System.Windows.Forms.Button
    Public WithEvents txtSelItem As System.Windows.Forms.TextBox
    Public WithEvents cmdExpHide As System.Windows.Forms.Button
    Public WithEvents cmdExpShow As System.Windows.Forms.Button
    Public WithEvents cmdItemStimulateSelected As System.Windows.Forms.Button
    Public WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents lblSelColumn As System.Windows.Forms.Label
    Public WithEvents lblSelItemLabel As System.Windows.Forms.Label
    Public WithEvents lblSelItemNr As System.Windows.Forms.Label
    Public WithEvents lblItemNr As System.Windows.Forms.Label
    Public WithEvents tbButtonLoad As System.Windows.Forms.ToolStripButton
    Public WithEvents tbButtonSaveAs As System.Windows.Forms.ToolStripButton
    Public WithEvents tbButtonLoadItemList As System.Windows.Forms.ToolStripButton
    Public WithEvents tbButtonSaveItemList As System.Windows.Forms.ToolStripButton
    Public WithEvents tbButtonSettings As System.Windows.Forms.ToolStripButton
    Public WithEvents tbButtonOptions As System.Windows.Forms.ToolStripButton
    Public WithEvents tbButtonConnect As System.Windows.Forms.ToolStripButton
    Public WithEvents tbButtonSnapshot As System.Windows.Forms.ToolStripButton
    Public WithEvents tbButtonShowStimulus As System.Windows.Forms.ToolStripButton
    Public WithEvents tbToolBar As System.Windows.Forms.ToolStrip
    Public WithEvents _sbStatusBar_Panel0 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel2 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel3 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel4 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel5 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents sbStatusBar As System.Windows.Forms.StatusStrip
    Public WithEvents imlToolbarIcons As System.Windows.Forms.ImageList
    Public WithEvents lineToolbar As System.Windows.Forms.Label
    Public WithEvents mnuFileNew As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFileLoad As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFileSaveAs As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFileBar0 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuItemClearList As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemLoadList As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemAppend As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemSaveListAs As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFileBar1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuBackupLogFileAs As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuQuickSave As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFileBar2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemUndo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuEditBar1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuItemCopy As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemClearCells As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemInsert As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemDuplicateBlock As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemDel As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemShuffleBlock As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemSetExperimentBlock As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemEditBar1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuItemRenumber As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOptColWidth As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemEdit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuViewStimulus As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSTIMLogList As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuRemoteMonitor As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuBar3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuViewSettings As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuBar2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuViewOptions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuConnectOutput As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuItemStimulateSelected As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuBarRun1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuStartExp As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuStartExpAtItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuBarRun2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuSnapshot As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuExp As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuHelpShortcuts As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdItemUndo = New System.Windows.Forms.Button()
        Me.cmdItemMoveDown = New System.Windows.Forms.Button()
        Me.cmdItemMoveUp = New System.Windows.Forms.Button()
        Me.cmdItemInsert = New System.Windows.Forms.Button()
        Me.cmdItemDel = New System.Windows.Forms.Button()
        Me.cmdItemMoveTop = New System.Windows.Forms.Button()
        Me.cmdItemMoveBottom = New System.Windows.Forms.Button()
        Me.imlItemList = New System.Windows.Forms.ImageList(Me.components)
        Me.lstStatus = New System.Windows.Forms.ListBox()
        Me.tmrStatus = New System.Windows.Forms.Timer(Me.components)
        Me.connectionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblWorkDir = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblExpType = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRootDir = New System.Windows.Forms.Label()
        Me.lblStimOutput = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tmrExp = New System.Windows.Forms.Timer(Me.components)
        Me.cmdItemBrowse = New System.Windows.Forms.Button()
        Me.cmbResult = New System.Windows.Forms.ListBox()
        Me.cmdTTShow = New System.Windows.Forms.Button()
        Me.chkExpRun = New System.Windows.Forms.CheckBox()
        Me.cmdItemStimulateAll = New System.Windows.Forms.Button()
        Me.cmdResultExecute = New System.Windows.Forms.Button()
        Me.cmdItemSortList = New System.Windows.Forms.Button()
        Me.cmdItemShuffleList = New System.Windows.Forms.Button()
        Me.cmdItemCreateList = New System.Windows.Forms.Button()
        Me.cmdCreateAllStimuli = New System.Windows.Forms.Button()
        Me.cmdItemAddRepetition = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdItemLogList = New System.Windows.Forms.Button()
        Me.cmdStartExp = New System.Windows.Forms.Button()
        Me.cmdItemSet = New System.Windows.Forms.Button()
        Me.txtSelItem = New System.Windows.Forms.TextBox()
        Me.cmdExpHide = New System.Windows.Forms.Button()
        Me.cmdExpShow = New System.Windows.Forms.Button()
        Me.cmdItemStimulateSelected = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSelColumn = New System.Windows.Forms.Label()
        Me.lblSelItemLabel = New System.Windows.Forms.Label()
        Me.lblSelItemNr = New System.Windows.Forms.Label()
        Me.lblItemNr = New System.Windows.Forms.Label()
        Me.popupMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxtmnuItemUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxtmnuItemCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuItemPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuItemClearCells = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuItemInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuItemDuplicateBlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuItemDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuItemShuffleBlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuFillAutomatically = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemSetFresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemSetProcessing = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemSetFinishedOK = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemSetFinishedWithErrors = New System.Windows.Forms.ToolStripMenuItem()
        Me.IgnoredToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxtmnuItemSetExperimentBlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuItemRenumber = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtmnuOptColWidth = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbToolBar = New System.Windows.Forms.ToolStrip()
        Me.imlToolbarIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.tbButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.tbButtonLoad = New System.Windows.Forms.ToolStripButton()
        Me.tbButtonSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbButtonLoadItemList = New System.Windows.Forms.ToolStripButton()
        Me.tbButtonSaveItemList = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbButtonSettings = New System.Windows.Forms.ToolStripButton()
        Me.tbButtonOptions = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbButtonConnect = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbButtonShowStimulus = New System.Windows.Forms.ToolStripButton()
        Me.tbButtonSnapshot = New System.Windows.Forms.ToolStripButton()
        Me.sbStatusBar = New System.Windows.Forms.StatusStrip()
        Me._sbStatusBar_Panel0 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lineToolbar = New System.Windows.Forms.Label()
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuItemClearList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemLoadList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemAppend = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemSaveListAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBackupLogFileAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuQuickSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuItemCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemClearCells = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemDuplicateBlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemShuffleBlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFillAutomatically = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemEditBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuItemSetExperimentBlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemRenumber = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptColWidth = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewStimulus = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSTIMLogList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoteMonitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoteMonitorConnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoteMonitorGetSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoteMonitorGetItemlist = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoteMonitorDisconnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoteMonitorDisconnectAllClients = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoteMonitorFollowCurrentItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoteMonitorUpdateSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBar3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBar2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConnectOutput = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemStimulateSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBarRun1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuStartExp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStartExpAtItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExpContinue = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBarRun2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSnapshot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLevelDancer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpShortcuts = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCheckForUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExpSuiteOnSourceforge = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenDocumentationFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplicationHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FWHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.cmdSanityCheck = New System.Windows.Forms.Button()
        Me.cmdInitialCheck = New System.Windows.Forms.Button()
        Me.cmdShowPlots = New System.Windows.Forms.Button()
        Me.cmdInitButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSetTo0 = New System.Windows.Forms.Button()
        Me.cmdTTsendTo0 = New System.Windows.Forms.Button()
        Me.labelTTaz = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.labelTTcalibrated = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.labelNcams = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.labelTrackingYesNo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.labelZ = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.labelY = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.labelX = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.labelRoll = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.labelPitch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.labelYaw = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTTShow = New System.Windows.Forms.Label()
        Me.cmdGenerateSOFA = New System.Windows.Forms.Button()
        Me.cmdContinueExp = New System.Windows.Forms.Button()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.PanelGeneral = New System.Windows.Forms.Panel()
        Me.PanelItemList = New System.Windows.Forms.Panel()
        Me.dgvItemList = New System.Windows.Forms.DataGridView()
        Me.PanelItemListRight = New System.Windows.Forms.Panel()
        Me.PanelItemListTop = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblItemList = New System.Windows.Forms.Label()
        Me.tmrTracker = New System.Windows.Forms.Timer(Me.components)
        Me.popupMenuStrip.SuspendLayout()
        Me.tbToolBar.SuspendLayout()
        Me.sbStatusBar.SuspendLayout()
        Me.MainMenu1.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.PanelGeneral.SuspendLayout()
        Me.PanelItemList.SuspendLayout()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelItemListRight.SuspendLayout()
        Me.PanelItemListTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdItemUndo
        '
        Me.cmdItemUndo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemUndo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemUndo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemUndo.Image = CType(resources.GetObject("cmdItemUndo.Image"), System.Drawing.Image)
        Me.cmdItemUndo.Location = New System.Drawing.Point(18, 75)
        Me.cmdItemUndo.Name = "cmdItemUndo"
        Me.cmdItemUndo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemUndo.Size = New System.Drawing.Size(23, 23)
        Me.cmdItemUndo.TabIndex = 42
        Me.cmdItemUndo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdItemUndo, "Undo last change in the item list")
        Me.cmdItemUndo.UseVisualStyleBackColor = False
        '
        'cmdItemMoveDown
        '
        Me.cmdItemMoveDown.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemMoveDown.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemMoveDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemMoveDown.Image = CType(resources.GetObject("cmdItemMoveDown.Image"), System.Drawing.Image)
        Me.cmdItemMoveDown.Location = New System.Drawing.Point(18, 187)
        Me.cmdItemMoveDown.Name = "cmdItemMoveDown"
        Me.cmdItemMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemMoveDown.Size = New System.Drawing.Size(23, 23)
        Me.cmdItemMoveDown.TabIndex = 45
        Me.cmdItemMoveDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdItemMoveDown, "Move selected items down")
        Me.cmdItemMoveDown.UseVisualStyleBackColor = False
        '
        'cmdItemMoveUp
        '
        Me.cmdItemMoveUp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemMoveUp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemMoveUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemMoveUp.Image = CType(resources.GetObject("cmdItemMoveUp.Image"), System.Drawing.Image)
        Me.cmdItemMoveUp.Location = New System.Drawing.Point(18, 38)
        Me.cmdItemMoveUp.Name = "cmdItemMoveUp"
        Me.cmdItemMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemMoveUp.Size = New System.Drawing.Size(23, 23)
        Me.cmdItemMoveUp.TabIndex = 41
        Me.cmdItemMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdItemMoveUp, "Move selected items up")
        Me.cmdItemMoveUp.UseVisualStyleBackColor = False
        '
        'cmdItemInsert
        '
        Me.cmdItemInsert.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemInsert.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemInsert.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemInsert.Image = CType(resources.GetObject("cmdItemInsert.Image"), System.Drawing.Image)
        Me.cmdItemInsert.Location = New System.Drawing.Point(18, 115)
        Me.cmdItemInsert.Name = "cmdItemInsert"
        Me.cmdItemInsert.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemInsert.Size = New System.Drawing.Size(23, 23)
        Me.cmdItemInsert.TabIndex = 43
        Me.cmdItemInsert.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdItemInsert, "Insert a new item")
        Me.cmdItemInsert.UseVisualStyleBackColor = False
        '
        'cmdItemDel
        '
        Me.cmdItemDel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemDel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemDel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemDel.Image = CType(resources.GetObject("cmdItemDel.Image"), System.Drawing.Image)
        Me.cmdItemDel.Location = New System.Drawing.Point(18, 143)
        Me.cmdItemDel.Name = "cmdItemDel"
        Me.cmdItemDel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemDel.Size = New System.Drawing.Size(23, 23)
        Me.cmdItemDel.TabIndex = 44
        Me.cmdItemDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdItemDel, "Delete selected items")
        Me.cmdItemDel.UseVisualStyleBackColor = False
        '
        'cmdItemMoveTop
        '
        Me.cmdItemMoveTop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemMoveTop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemMoveTop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemMoveTop.Image = CType(resources.GetObject("cmdItemMoveTop.Image"), System.Drawing.Image)
        Me.cmdItemMoveTop.Location = New System.Drawing.Point(18, 8)
        Me.cmdItemMoveTop.Name = "cmdItemMoveTop"
        Me.cmdItemMoveTop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemMoveTop.Size = New System.Drawing.Size(23, 23)
        Me.cmdItemMoveTop.TabIndex = 40
        Me.cmdItemMoveTop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdItemMoveTop, "Move selected items to the top")
        Me.cmdItemMoveTop.UseVisualStyleBackColor = False
        '
        'cmdItemMoveBottom
        '
        Me.cmdItemMoveBottom.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemMoveBottom.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemMoveBottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemMoveBottom.Image = CType(resources.GetObject("cmdItemMoveBottom.Image"), System.Drawing.Image)
        Me.cmdItemMoveBottom.Location = New System.Drawing.Point(18, 216)
        Me.cmdItemMoveBottom.Name = "cmdItemMoveBottom"
        Me.cmdItemMoveBottom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemMoveBottom.Size = New System.Drawing.Size(23, 23)
        Me.cmdItemMoveBottom.TabIndex = 46
        Me.cmdItemMoveBottom.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdItemMoveBottom, "Move selected items to the bottom")
        Me.cmdItemMoveBottom.UseVisualStyleBackColor = False
        '
        'imlItemList
        '
        Me.imlItemList.ImageStream = CType(resources.GetObject("imlItemList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlItemList.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.imlItemList.Images.SetKeyName(0, "Copy")
        Me.imlItemList.Images.SetKeyName(1, "DeleteRow")
        Me.imlItemList.Images.SetKeyName(2, "InsertRow")
        '
        'lstStatus
        '
        Me.lstStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstStatus.BackColor = System.Drawing.SystemColors.Window
        Me.lstStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstStatus.Location = New System.Drawing.Point(332, 3)
        Me.lstStatus.Name = "lstStatus"
        Me.lstStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstStatus.Size = New System.Drawing.Size(532, 95)
        Me.lstStatus.TabIndex = 38
        '
        'tmrStatus
        '
        Me.tmrStatus.Interval = 500
        '
        'connectionTimer
        '
        Me.connectionTimer.Interval = 500
        '
        'lblWorkDir
        '
        Me.lblWorkDir.BackColor = System.Drawing.SystemColors.Control
        Me.lblWorkDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWorkDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWorkDir.Location = New System.Drawing.Point(65, 69)
        Me.lblWorkDir.Name = "lblWorkDir"
        Me.lblWorkDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWorkDir.Size = New System.Drawing.Size(266, 13)
        Me.lblWorkDir.TabIndex = 44
        Me.lblWorkDir.Text = "not connected"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(3, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Work Dir:"
        '
        'lblExpType
        '
        Me.lblExpType.BackColor = System.Drawing.SystemColors.Control
        Me.lblExpType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExpType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExpType.Location = New System.Drawing.Point(105, 9)
        Me.lblExpType.Name = "lblExpType"
        Me.lblExpType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExpType.Size = New System.Drawing.Size(227, 13)
        Me.lblExpType.TabIndex = 36
        Me.lblExpType.Text = "XXX"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(3, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Experiment Type:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(3, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Root Dir:"
        '
        'lblRootDir
        '
        Me.lblRootDir.BackColor = System.Drawing.SystemColors.Control
        Me.lblRootDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRootDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRootDir.Location = New System.Drawing.Point(65, 49)
        Me.lblRootDir.Name = "lblRootDir"
        Me.lblRootDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRootDir.Size = New System.Drawing.Size(265, 13)
        Me.lblRootDir.TabIndex = 33
        Me.lblRootDir.Text = "XXX"
        '
        'lblStimOutput
        '
        Me.lblStimOutput.BackColor = System.Drawing.SystemColors.Control
        Me.lblStimOutput.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStimOutput.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStimOutput.Location = New System.Drawing.Point(105, 29)
        Me.lblStimOutput.Name = "lblStimOutput"
        Me.lblStimOutput.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStimOutput.Size = New System.Drawing.Size(225, 20)
        Me.lblStimOutput.TabIndex = 31
        Me.lblStimOutput.Text = "XXX"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(3, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Signal (Output):"
        '
        'tmrExp
        '
        Me.tmrExp.Interval = 1
        '
        'cmdItemBrowse
        '
        Me.cmdItemBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemBrowse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemBrowse.Location = New System.Drawing.Point(327, 30)
        Me.cmdItemBrowse.Name = "cmdItemBrowse"
        Me.cmdItemBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemBrowse.Size = New System.Drawing.Size(25, 21)
        Me.cmdItemBrowse.TabIndex = 56
        Me.cmdItemBrowse.Text = "..."
        Me.cmdItemBrowse.UseVisualStyleBackColor = False
        '
        'cmbResult
        '
        Me.cmbResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbResult.BackColor = System.Drawing.SystemColors.Window
        Me.cmbResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbResult.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbResult.Location = New System.Drawing.Point(621, 63)
        Me.cmbResult.Name = "cmbResult"
        Me.cmbResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbResult.Size = New System.Drawing.Size(152, 95)
        Me.cmbResult.TabIndex = 55
        '
        'cmdTTShow
        '
        Me.cmdTTShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTTShow.BackColor = System.Drawing.SystemColors.Control
        Me.cmdTTShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdTTShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTTShow.Location = New System.Drawing.Point(9, 44)
        Me.cmdTTShow.Name = "cmdTTShow"
        Me.cmdTTShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdTTShow.Size = New System.Drawing.Size(88, 21)
        Me.cmdTTShow.TabIndex = 50
        Me.cmdTTShow.Text = "Show Interface"
        Me.cmdTTShow.UseVisualStyleBackColor = False
        '
        'chkExpRun
        '
        Me.chkExpRun.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkExpRun.BackColor = System.Drawing.SystemColors.Control
        Me.chkExpRun.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkExpRun.Enabled = False
        Me.chkExpRun.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkExpRun.Location = New System.Drawing.Point(463, 195)
        Me.chkExpRun.Name = "chkExpRun"
        Me.chkExpRun.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkExpRun.Size = New System.Drawing.Size(109, 24)
        Me.chkExpRun.TabIndex = 41
        Me.chkExpRun.Text = "Run Experiment"
        Me.chkExpRun.UseVisualStyleBackColor = False
        Me.chkExpRun.Visible = False
        '
        'cmdItemStimulateAll
        '
        Me.cmdItemStimulateAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemStimulateAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemStimulateAll.Enabled = False
        Me.cmdItemStimulateAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemStimulateAll.Location = New System.Drawing.Point(29, 65)
        Me.cmdItemStimulateAll.Name = "cmdItemStimulateAll"
        Me.cmdItemStimulateAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemStimulateAll.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemStimulateAll.TabIndex = 3
        Me.cmdItemStimulateAll.Text = "Stimulate All"
        Me.cmdItemStimulateAll.UseVisualStyleBackColor = False
        Me.cmdItemStimulateAll.Visible = False
        '
        'cmdResultExecute
        '
        Me.cmdResultExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdResultExecute.BackColor = System.Drawing.SystemColors.Control
        Me.cmdResultExecute.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdResultExecute.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdResultExecute.Location = New System.Drawing.Point(779, 97)
        Me.cmdResultExecute.Name = "cmdResultExecute"
        Me.cmdResultExecute.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdResultExecute.Size = New System.Drawing.Size(44, 27)
        Me.cmdResultExecute.TabIndex = 11
        Me.cmdResultExecute.Text = "Run"
        Me.cmdResultExecute.UseVisualStyleBackColor = False
        '
        'cmdItemSortList
        '
        Me.cmdItemSortList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemSortList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemSortList.Enabled = False
        Me.cmdItemSortList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemSortList.Location = New System.Drawing.Point(29, 137)
        Me.cmdItemSortList.Name = "cmdItemSortList"
        Me.cmdItemSortList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemSortList.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemSortList.TabIndex = 6
        Me.cmdItemSortList.Text = "Sort List"
        Me.cmdItemSortList.UseVisualStyleBackColor = False
        Me.cmdItemSortList.Visible = False
        '
        'cmdItemShuffleList
        '
        Me.cmdItemShuffleList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemShuffleList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemShuffleList.Enabled = False
        Me.cmdItemShuffleList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemShuffleList.Location = New System.Drawing.Point(29, 113)
        Me.cmdItemShuffleList.Name = "cmdItemShuffleList"
        Me.cmdItemShuffleList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemShuffleList.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemShuffleList.TabIndex = 5
        Me.cmdItemShuffleList.Text = "Shuffle List"
        Me.cmdItemShuffleList.UseVisualStyleBackColor = False
        Me.cmdItemShuffleList.Visible = False
        '
        'cmdItemCreateList
        '
        Me.cmdItemCreateList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemCreateList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemCreateList.Enabled = False
        Me.cmdItemCreateList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemCreateList.Location = New System.Drawing.Point(29, 17)
        Me.cmdItemCreateList.Name = "cmdItemCreateList"
        Me.cmdItemCreateList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemCreateList.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemCreateList.TabIndex = 1
        Me.cmdItemCreateList.Text = "Create List"
        Me.cmdItemCreateList.UseVisualStyleBackColor = False
        Me.cmdItemCreateList.Visible = False
        '
        'cmdCreateAllStimuli
        '
        Me.cmdCreateAllStimuli.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCreateAllStimuli.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCreateAllStimuli.Enabled = False
        Me.cmdCreateAllStimuli.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCreateAllStimuli.Location = New System.Drawing.Point(29, 41)
        Me.cmdCreateAllStimuli.Name = "cmdCreateAllStimuli"
        Me.cmdCreateAllStimuli.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCreateAllStimuli.Size = New System.Drawing.Size(101, 21)
        Me.cmdCreateAllStimuli.TabIndex = 2
        Me.cmdCreateAllStimuli.Text = "Create All Stimuli"
        Me.cmdCreateAllStimuli.UseVisualStyleBackColor = False
        Me.cmdCreateAllStimuli.Visible = False
        '
        'cmdItemAddRepetition
        '
        Me.cmdItemAddRepetition.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemAddRepetition.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemAddRepetition.Enabled = False
        Me.cmdItemAddRepetition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemAddRepetition.Location = New System.Drawing.Point(29, 89)
        Me.cmdItemAddRepetition.Name = "cmdItemAddRepetition"
        Me.cmdItemAddRepetition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemAddRepetition.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemAddRepetition.TabIndex = 4
        Me.cmdItemAddRepetition.Text = "Add Repetition"
        Me.cmdItemAddRepetition.UseVisualStyleBackColor = False
        Me.cmdItemAddRepetition.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCancel.Location = New System.Drawing.Point(327, 140)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(118, 50)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdItemLogList
        '
        Me.cmdItemLogList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemLogList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemLogList.Enabled = False
        Me.cmdItemLogList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemLogList.Location = New System.Drawing.Point(29, 161)
        Me.cmdItemLogList.Name = "cmdItemLogList"
        Me.cmdItemLogList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemLogList.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemLogList.TabIndex = 7
        Me.cmdItemLogList.Text = "Log List"
        Me.cmdItemLogList.UseVisualStyleBackColor = False
        Me.cmdItemLogList.Visible = False
        '
        'cmdStartExp
        '
        Me.cmdStartExp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdStartExp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStartExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStartExp.Enabled = False
        Me.cmdStartExp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStartExp.Image = CType(resources.GetObject("cmdStartExp.Image"), System.Drawing.Image)
        Me.cmdStartExp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdStartExp.Location = New System.Drawing.Point(453, 83)
        Me.cmdStartExp.Name = "cmdStartExp"
        Me.cmdStartExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStartExp.Size = New System.Drawing.Size(118, 50)
        Me.cmdStartExp.TabIndex = 9
        Me.cmdStartExp.Text = "Start Experiment"
        Me.cmdStartExp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStartExp.UseVisualStyleBackColor = False
        Me.cmdStartExp.Visible = False
        '
        'cmdItemSet
        '
        Me.cmdItemSet.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemSet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemSet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemSet.Image = CType(resources.GetObject("cmdItemSet.Image"), System.Drawing.Image)
        Me.cmdItemSet.Location = New System.Drawing.Point(299, 30)
        Me.cmdItemSet.Name = "cmdItemSet"
        Me.cmdItemSet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemSet.Size = New System.Drawing.Size(25, 21)
        Me.cmdItemSet.TabIndex = 12
        Me.cmdItemSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdItemSet.UseVisualStyleBackColor = False
        '
        'txtSelItem
        '
        Me.txtSelItem.AcceptsReturn = True
        Me.txtSelItem.BackColor = System.Drawing.SystemColors.Window
        Me.txtSelItem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSelItem.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSelItem.Location = New System.Drawing.Point(78, 31)
        Me.txtSelItem.MaxLength = 0
        Me.txtSelItem.Name = "txtSelItem"
        Me.txtSelItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSelItem.Size = New System.Drawing.Size(215, 20)
        Me.txtSelItem.TabIndex = 13
        '
        'cmdExpHide
        '
        Me.cmdExpHide.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExpHide.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExpHide.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpHide.Enabled = False
        Me.cmdExpHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpHide.Location = New System.Drawing.Point(795, 5)
        Me.cmdExpHide.Name = "cmdExpHide"
        Me.cmdExpHide.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpHide.Size = New System.Drawing.Size(42, 21)
        Me.cmdExpHide.TabIndex = 16
        Me.cmdExpHide.Text = "Hide"
        Me.cmdExpHide.UseVisualStyleBackColor = False
        Me.cmdExpHide.Visible = False
        '
        'cmdExpShow
        '
        Me.cmdExpShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExpShow.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExpShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpShow.Enabled = False
        Me.cmdExpShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpShow.Location = New System.Drawing.Point(750, 5)
        Me.cmdExpShow.Name = "cmdExpShow"
        Me.cmdExpShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpShow.Size = New System.Drawing.Size(42, 21)
        Me.cmdExpShow.TabIndex = 15
        Me.cmdExpShow.Text = "Show"
        Me.cmdExpShow.UseVisualStyleBackColor = False
        Me.cmdExpShow.Visible = False
        '
        'cmdItemStimulateSelected
        '
        Me.cmdItemStimulateSelected.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdItemStimulateSelected.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemStimulateSelected.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemStimulateSelected.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemStimulateSelected.Image = CType(resources.GetObject("cmdItemStimulateSelected.Image"), System.Drawing.Image)
        Me.cmdItemStimulateSelected.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdItemStimulateSelected.Location = New System.Drawing.Point(327, 83)
        Me.cmdItemStimulateSelected.Name = "cmdItemStimulateSelected"
        Me.cmdItemStimulateSelected.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemStimulateSelected.Size = New System.Drawing.Size(118, 50)
        Me.cmdItemStimulateSelected.TabIndex = 8
        Me.cmdItemStimulateSelected.Text = "Stimulate Selected"
        Me.cmdItemStimulateSelected.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdItemStimulateSelected.UseVisualStyleBackColor = False
        '
        'pbStatus
        '
        Me.pbStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStatus.Location = New System.Drawing.Point(0, 213)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(876, 24)
        Me.pbStatus.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Enabled = False
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(636, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(110, 17)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Experiment Screen:"
        Me.Label5.Visible = False
        '
        'lblSelColumn
        '
        Me.lblSelColumn.BackColor = System.Drawing.SystemColors.Control
        Me.lblSelColumn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSelColumn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSelColumn.Location = New System.Drawing.Point(-2, 21)
        Me.lblSelColumn.Name = "lblSelColumn"
        Me.lblSelColumn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSelColumn.Size = New System.Drawing.Size(74, 33)
        Me.lblSelColumn.TabIndex = 26
        Me.lblSelColumn.Text = "Item:"
        Me.lblSelColumn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSelItemLabel
        '
        Me.lblSelItemLabel.AutoSize = True
        Me.lblSelItemLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblSelItemLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSelItemLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSelItemLabel.Location = New System.Drawing.Point(358, 35)
        Me.lblSelItemLabel.Name = "lblSelItemLabel"
        Me.lblSelItemLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSelItemLabel.Size = New System.Drawing.Size(80, 13)
        Me.lblSelItemLabel.TabIndex = 25
        Me.lblSelItemLabel.Text = "Selected Items:"
        Me.lblSelItemLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSelItemNr
        '
        Me.lblSelItemNr.AutoSize = True
        Me.lblSelItemNr.BackColor = System.Drawing.SystemColors.Control
        Me.lblSelItemNr.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSelItemNr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSelItemNr.Location = New System.Drawing.Point(444, 35)
        Me.lblSelItemNr.Name = "lblSelItemNr"
        Me.lblSelItemNr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSelItemNr.Size = New System.Drawing.Size(16, 13)
        Me.lblSelItemNr.TabIndex = 24
        Me.lblSelItemNr.Text = "---"
        '
        'lblItemNr
        '
        Me.lblItemNr.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemNr.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItemNr.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblItemNr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemNr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItemNr.Location = New System.Drawing.Point(0, 188)
        Me.lblItemNr.Margin = New System.Windows.Forms.Padding(3, 0, 3, 5)
        Me.lblItemNr.Name = "lblItemNr"
        Me.lblItemNr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItemNr.Size = New System.Drawing.Size(57, 25)
        Me.lblItemNr.TabIndex = 23
        Me.lblItemNr.Text = "Empty"
        Me.lblItemNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'popupMenuStrip
        '
        Me.popupMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.popupMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxtmnuItemUndo, Me.ToolStripSeparator6, Me.ctxtmnuItemCopy, Me.ctxtmnuItemPaste, Me.ctxtmnuItemClearCells, Me.ctxtmnuItemInsert, Me.ctxtmnuItemDuplicateBlock, Me.ctxtmnuItemDel, Me.ctxtmnuItemShuffleBlock, Me.ctxtmnuFillAutomatically, Me.ToolStripMenuItem1, Me.ToolStripSeparator7, Me.ctxtmnuItemSetExperimentBlock, Me.ctxtmnuItemRenumber, Me.ctxtmnuOptColWidth})
        Me.popupMenuStrip.Name = "popupMenuStrip"
        Me.popupMenuStrip.Size = New System.Drawing.Size(274, 302)
        '
        'ctxtmnuItemUndo
        '
        Me.ctxtmnuItemUndo.Name = "ctxtmnuItemUndo"
        Me.ctxtmnuItemUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.ctxtmnuItemUndo.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemUndo.Text = "&Undo"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(270, 6)
        '
        'ctxtmnuItemCopy
        '
        Me.ctxtmnuItemCopy.Name = "ctxtmnuItemCopy"
        Me.ctxtmnuItemCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ctxtmnuItemCopy.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemCopy.Text = "Copy to Clipboard"
        '
        'ctxtmnuItemPaste
        '
        Me.ctxtmnuItemPaste.Name = "ctxtmnuItemPaste"
        Me.ctxtmnuItemPaste.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.ctxtmnuItemPaste.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemPaste.Text = "Paste to Item List"
        '
        'ctxtmnuItemClearCells
        '
        Me.ctxtmnuItemClearCells.Name = "ctxtmnuItemClearCells"
        Me.ctxtmnuItemClearCells.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemClearCells.Text = "&Clear Items"
        '
        'ctxtmnuItemInsert
        '
        Me.ctxtmnuItemInsert.Name = "ctxtmnuItemInsert"
        Me.ctxtmnuItemInsert.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.ctxtmnuItemInsert.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemInsert.Text = "&Insert Item"
        '
        'ctxtmnuItemDuplicateBlock
        '
        Me.ctxtmnuItemDuplicateBlock.Name = "ctxtmnuItemDuplicateBlock"
        Me.ctxtmnuItemDuplicateBlock.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ctxtmnuItemDuplicateBlock.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemDuplicateBlock.Text = "D&uplicate Items"
        '
        'ctxtmnuItemDel
        '
        Me.ctxtmnuItemDel.Name = "ctxtmnuItemDel"
        Me.ctxtmnuItemDel.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ctxtmnuItemDel.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemDel.Text = "&Remove Items"
        '
        'ctxtmnuItemShuffleBlock
        '
        Me.ctxtmnuItemShuffleBlock.Name = "ctxtmnuItemShuffleBlock"
        Me.ctxtmnuItemShuffleBlock.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemShuffleBlock.Text = "&Shuffle Items"
        '
        'ctxtmnuFillAutomatically
        '
        Me.ctxtmnuFillAutomatically.Name = "ctxtmnuFillAutomatically"
        Me.ctxtmnuFillAutomatically.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuFillAutomatically.Text = "&Fill automatically with numeric values"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemSetFresh, Me.mnuItemSetProcessing, Me.mnuItemSetFinishedOK, Me.mnuItemSetFinishedWithErrors, Me.IgnoredToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(273, 22)
        Me.ToolStripMenuItem1.Text = "Set Status"
        '
        'mnuItemSetFresh
        '
        Me.mnuItemSetFresh.Name = "mnuItemSetFresh"
        Me.mnuItemSetFresh.Size = New System.Drawing.Size(177, 22)
        Me.mnuItemSetFresh.Text = "Fresh"
        '
        'mnuItemSetProcessing
        '
        Me.mnuItemSetProcessing.Name = "mnuItemSetProcessing"
        Me.mnuItemSetProcessing.Size = New System.Drawing.Size(177, 22)
        Me.mnuItemSetProcessing.Text = "Processing"
        '
        'mnuItemSetFinishedOK
        '
        Me.mnuItemSetFinishedOK.Name = "mnuItemSetFinishedOK"
        Me.mnuItemSetFinishedOK.Size = New System.Drawing.Size(177, 22)
        Me.mnuItemSetFinishedOK.Text = "Finished OK"
        '
        'mnuItemSetFinishedWithErrors
        '
        Me.mnuItemSetFinishedWithErrors.Name = "mnuItemSetFinishedWithErrors"
        Me.mnuItemSetFinishedWithErrors.Size = New System.Drawing.Size(177, 22)
        Me.mnuItemSetFinishedWithErrors.Text = "Finished with Errors"
        '
        'IgnoredToolStripMenuItem
        '
        Me.IgnoredToolStripMenuItem.Name = "IgnoredToolStripMenuItem"
        Me.IgnoredToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.IgnoredToolStripMenuItem.Text = "Ignored"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(270, 6)
        '
        'ctxtmnuItemSetExperimentBlock
        '
        Me.ctxtmnuItemSetExperimentBlock.Name = "ctxtmnuItemSetExperimentBlock"
        Me.ctxtmnuItemSetExperimentBlock.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemSetExperimentBlock.Text = "Set Experiment Item Range"
        '
        'ctxtmnuItemRenumber
        '
        Me.ctxtmnuItemRenumber.Name = "ctxtmnuItemRenumber"
        Me.ctxtmnuItemRenumber.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuItemRenumber.Text = "Renumber Index"
        '
        'ctxtmnuOptColWidth
        '
        Me.ctxtmnuOptColWidth.Name = "ctxtmnuOptColWidth"
        Me.ctxtmnuOptColWidth.Size = New System.Drawing.Size(273, 22)
        Me.ctxtmnuOptColWidth.Text = "Set Optimal Column Width"
        '
        'tbToolBar
        '
        Me.tbToolBar.ImageList = Me.imlToolbarIcons
        Me.tbToolBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tbToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbButtonNew, Me.tbButtonLoad, Me.tbButtonSaveAs, Me.ToolStripSeparator1, Me.tbButtonLoadItemList, Me.tbButtonSaveItemList, Me.ToolStripSeparator2, Me.tbButtonSettings, Me.tbButtonOptions, Me.ToolStripSeparator4, Me.tbButtonConnect, Me.ToolStripSeparator3, Me.tbButtonShowStimulus, Me.tbButtonSnapshot})
        Me.tbToolBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tbToolBar.Location = New System.Drawing.Point(0, 24)
        Me.tbToolBar.Name = "tbToolBar"
        Me.tbToolBar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbToolBar.Size = New System.Drawing.Size(876, 25)
        Me.tbToolBar.TabIndex = 18
        '
        'imlToolbarIcons
        '
        Me.imlToolbarIcons.ImageStream = CType(resources.GetObject("imlToolbarIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlToolbarIcons.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.imlToolbarIcons.Images.SetKeyName(0, "New")
        Me.imlToolbarIcons.Images.SetKeyName(1, "Load")
        Me.imlToolbarIcons.Images.SetKeyName(2, "SaveAs")
        Me.imlToolbarIcons.Images.SetKeyName(3, "Settings")
        Me.imlToolbarIcons.Images.SetKeyName(4, "Options")
        Me.imlToolbarIcons.Images.SetKeyName(5, "Stimulation")
        Me.imlToolbarIcons.Images.SetKeyName(6, "ShowStimulus")
        Me.imlToolbarIcons.Images.SetKeyName(7, "Snapshot")
        Me.imlToolbarIcons.Images.SetKeyName(8, "Go")
        Me.imlToolbarIcons.Images.SetKeyName(9, "")
        Me.imlToolbarIcons.Images.SetKeyName(10, "")
        '
        'tbButtonNew
        '
        Me.tbButtonNew.AutoSize = False
        Me.tbButtonNew.Image = CType(resources.GetObject("tbButtonNew.Image"), System.Drawing.Image)
        Me.tbButtonNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonNew.Name = "tbButtonNew"
        Me.tbButtonNew.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonNew.ToolTipText = "New settings"
        '
        'tbButtonLoad
        '
        Me.tbButtonLoad.AutoSize = False
        Me.tbButtonLoad.Image = CType(resources.GetObject("tbButtonLoad.Image"), System.Drawing.Image)
        Me.tbButtonLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonLoad.Name = "tbButtonLoad"
        Me.tbButtonLoad.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonLoad.ToolTipText = "Open settings"
        '
        'tbButtonSaveAs
        '
        Me.tbButtonSaveAs.AutoSize = False
        Me.tbButtonSaveAs.Enabled = False
        Me.tbButtonSaveAs.Image = CType(resources.GetObject("tbButtonSaveAs.Image"), System.Drawing.Image)
        Me.tbButtonSaveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonSaveAs.Name = "tbButtonSaveAs"
        Me.tbButtonSaveAs.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonSaveAs.ToolTipText = "Save settings as..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tbButtonLoadItemList
        '
        Me.tbButtonLoadItemList.AutoSize = False
        Me.tbButtonLoadItemList.Image = CType(resources.GetObject("tbButtonLoadItemList.Image"), System.Drawing.Image)
        Me.tbButtonLoadItemList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonLoadItemList.Name = "tbButtonLoadItemList"
        Me.tbButtonLoadItemList.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonLoadItemList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonLoadItemList.ToolTipText = "Load Item List"
        '
        'tbButtonSaveItemList
        '
        Me.tbButtonSaveItemList.AutoSize = False
        Me.tbButtonSaveItemList.Image = CType(resources.GetObject("tbButtonSaveItemList.Image"), System.Drawing.Image)
        Me.tbButtonSaveItemList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonSaveItemList.Name = "tbButtonSaveItemList"
        Me.tbButtonSaveItemList.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonSaveItemList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonSaveItemList.ToolTipText = "Save Item List As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Padding = New System.Windows.Forms.Padding(5)
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tbButtonSettings
        '
        Me.tbButtonSettings.AutoSize = False
        Me.tbButtonSettings.Image = CType(resources.GetObject("tbButtonSettings.Image"), System.Drawing.Image)
        Me.tbButtonSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonSettings.Name = "tbButtonSettings"
        Me.tbButtonSettings.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonSettings.ToolTipText = "Show settings"
        '
        'tbButtonOptions
        '
        Me.tbButtonOptions.AutoSize = False
        Me.tbButtonOptions.Image = CType(resources.GetObject("tbButtonOptions.Image"), System.Drawing.Image)
        Me.tbButtonOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonOptions.Name = "tbButtonOptions"
        Me.tbButtonOptions.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonOptions.ToolTipText = "Program options"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tbButtonConnect
        '
        Me.tbButtonConnect.AutoSize = False
        Me.tbButtonConnect.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbButtonConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.tbButtonConnect.CheckOnClick = True
        Me.tbButtonConnect.Image = CType(resources.GetObject("tbButtonConnect.Image"), System.Drawing.Image)
        Me.tbButtonConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonConnect.Name = "tbButtonConnect"
        Me.tbButtonConnect.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonConnect.ToolTipText = "Connect to output"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tbButtonShowStimulus
        '
        Me.tbButtonShowStimulus.AutoSize = False
        Me.tbButtonShowStimulus.Image = CType(resources.GetObject("tbButtonShowStimulus.Image"), System.Drawing.Image)
        Me.tbButtonShowStimulus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonShowStimulus.Name = "tbButtonShowStimulus"
        Me.tbButtonShowStimulus.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonShowStimulus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonShowStimulus.ToolTipText = "Show stimulus array before assembling..."
        '
        'tbButtonSnapshot
        '
        Me.tbButtonSnapshot.AutoSize = False
        Me.tbButtonSnapshot.Image = CType(resources.GetObject("tbButtonSnapshot.Image"), System.Drawing.Image)
        Me.tbButtonSnapshot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbButtonSnapshot.Name = "tbButtonSnapshot"
        Me.tbButtonSnapshot.Size = New System.Drawing.Size(24, 22)
        Me.tbButtonSnapshot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbButtonSnapshot.ToolTipText = "Create a snapshot in the log file"
        '
        'sbStatusBar
        '
        Me.sbStatusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.sbStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._sbStatusBar_Panel0, Me._sbStatusBar_Panel1, Me._sbStatusBar_Panel2, Me._sbStatusBar_Panel3, Me._sbStatusBar_Panel4, Me._sbStatusBar_Panel5})
        Me.sbStatusBar.Location = New System.Drawing.Point(0, 663)
        Me.sbStatusBar.Name = "sbStatusBar"
        Me.sbStatusBar.Size = New System.Drawing.Size(876, 24)
        Me.sbStatusBar.TabIndex = 0
        '
        '_sbStatusBar_Panel0
        '
        Me._sbStatusBar_Panel0.AutoSize = False
        Me._sbStatusBar_Panel0.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel0.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel0.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel0.Name = "_sbStatusBar_Panel0"
        Me._sbStatusBar_Panel0.Size = New System.Drawing.Size(450, 24)
        Me._sbStatusBar_Panel0.Spring = True
        Me._sbStatusBar_Panel0.Text = "Status"
        Me._sbStatusBar_Panel0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._sbStatusBar_Panel0.ToolTipText = "Current Status"
        '
        '_sbStatusBar_Panel1
        '
        Me._sbStatusBar_Panel1.AutoSize = False
        Me._sbStatusBar_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel1.Name = "_sbStatusBar_Panel1"
        Me._sbStatusBar_Panel1.Size = New System.Drawing.Size(96, 24)
        Me._sbStatusBar_Panel1.ToolTipText = "Implant type used for the LEFT ear"
        '
        '_sbStatusBar_Panel2
        '
        Me._sbStatusBar_Panel2.AutoSize = False
        Me._sbStatusBar_Panel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel2.Name = "_sbStatusBar_Panel2"
        Me._sbStatusBar_Panel2.Size = New System.Drawing.Size(96, 24)
        Me._sbStatusBar_Panel2.ToolTipText = "Implant type used for the RIGHT ear"
        '
        '_sbStatusBar_Panel3
        '
        Me._sbStatusBar_Panel3.AutoSize = False
        Me._sbStatusBar_Panel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel3.Name = "_sbStatusBar_Panel3"
        Me._sbStatusBar_Panel3.Size = New System.Drawing.Size(73, 24)
        Me._sbStatusBar_Panel3.ToolTipText = "Experiment time"
        '
        '_sbStatusBar_Panel4
        '
        Me._sbStatusBar_Panel4.AutoSize = False
        Me._sbStatusBar_Panel4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel4.Name = "_sbStatusBar_Panel4"
        Me._sbStatusBar_Panel4.Size = New System.Drawing.Size(73, 24)
        Me._sbStatusBar_Panel4.ToolTipText = "Estimated Time of the end of Experiment"
        '
        '_sbStatusBar_Panel5
        '
        Me._sbStatusBar_Panel5.AutoSize = False
        Me._sbStatusBar_Panel5.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel5.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel5.Image = Global.ExpSuite.My.Resources.Resources.network_offline
        Me._sbStatusBar_Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel5.Name = "_sbStatusBar_Panel5"
        Me._sbStatusBar_Panel5.Size = New System.Drawing.Size(73, 24)
        Me._sbStatusBar_Panel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._sbStatusBar_Panel5.ToolTipText = "Real Time Clock"
        '
        'lineToolbar
        '
        Me.lineToolbar.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lineToolbar.Location = New System.Drawing.Point(0, 28)
        Me.lineToolbar.Name = "lineToolbar"
        Me.lineToolbar.Size = New System.Drawing.Size(600, 1)
        Me.lineToolbar.TabIndex = 60
        '
        'MainMenu1
        '
        Me.MainMenu1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuItemEdit, Me.mnuView, Me.mnuExp, Me.mnuHelp})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(876, 24)
        Me.MainMenu1.TabIndex = 61
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNew, Me.mnuFileLoad, Me.mnuFileSaveAs, Me.mnuFileBar0, Me.mnuItemClearList, Me.mnuItemLoadList, Me.mnuItemAppend, Me.mnuItemSaveListAs, Me.mnuFileBar1, Me.mnuBackupLogFileAs, Me.mnuQuickSave, Me.mnuFileBar2, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Name = "mnuFileNew"
        Me.mnuFileNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuFileNew.Size = New System.Drawing.Size(208, 22)
        Me.mnuFileNew.Text = "&New settings"
        '
        'mnuFileLoad
        '
        Me.mnuFileLoad.Name = "mnuFileLoad"
        Me.mnuFileLoad.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mnuFileLoad.Size = New System.Drawing.Size(208, 22)
        Me.mnuFileLoad.Text = "&Open settings..."
        '
        'mnuFileSaveAs
        '
        Me.mnuFileSaveAs.Enabled = False
        Me.mnuFileSaveAs.Name = "mnuFileSaveAs"
        Me.mnuFileSaveAs.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuFileSaveAs.Size = New System.Drawing.Size(208, 22)
        Me.mnuFileSaveAs.Text = "&Save settings as..."
        '
        'mnuFileBar0
        '
        Me.mnuFileBar0.Name = "mnuFileBar0"
        Me.mnuFileBar0.Size = New System.Drawing.Size(205, 6)
        '
        'mnuItemClearList
        '
        Me.mnuItemClearList.Name = "mnuItemClearList"
        Me.mnuItemClearList.Size = New System.Drawing.Size(208, 22)
        Me.mnuItemClearList.Text = "&Clear item list"
        '
        'mnuItemLoadList
        '
        Me.mnuItemLoadList.Name = "mnuItemLoadList"
        Me.mnuItemLoadList.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.mnuItemLoadList.Size = New System.Drawing.Size(208, 22)
        Me.mnuItemLoadList.Text = "&Load item list..."
        '
        'mnuItemAppend
        '
        Me.mnuItemAppend.Name = "mnuItemAppend"
        Me.mnuItemAppend.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.mnuItemAppend.Size = New System.Drawing.Size(208, 22)
        Me.mnuItemAppend.Text = "&Append item list..."
        '
        'mnuItemSaveListAs
        '
        Me.mnuItemSaveListAs.Name = "mnuItemSaveListAs"
        Me.mnuItemSaveListAs.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnuItemSaveListAs.Size = New System.Drawing.Size(208, 22)
        Me.mnuItemSaveListAs.Text = "Sav&e item list as..."
        '
        'mnuFileBar1
        '
        Me.mnuFileBar1.Name = "mnuFileBar1"
        Me.mnuFileBar1.Size = New System.Drawing.Size(205, 6)
        '
        'mnuBackupLogFileAs
        '
        Me.mnuBackupLogFileAs.Name = "mnuBackupLogFileAs"
        Me.mnuBackupLogFileAs.Size = New System.Drawing.Size(208, 22)
        Me.mnuBackupLogFileAs.Text = "&Backup Log File As..."
        '
        'mnuQuickSave
        '
        Me.mnuQuickSave.Name = "mnuQuickSave"
        Me.mnuQuickSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.mnuQuickSave.Size = New System.Drawing.Size(208, 22)
        Me.mnuQuickSave.Text = "&Quick Save..."
        '
        'mnuFileBar2
        '
        Me.mnuFileBar2.Name = "mnuFileBar2"
        Me.mnuFileBar2.Size = New System.Drawing.Size(205, 6)
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(208, 22)
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuItemEdit
        '
        Me.mnuItemEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemUndo, Me.mnuEditBar1, Me.mnuItemCopy, Me.mnuItemPaste, Me.mnuItemClearCells, Me.mnuItemInsert, Me.mnuItemDuplicateBlock, Me.mnuItemDel, Me.mnuItemShuffleBlock, Me.mnuFillAutomatically, Me.mnuItemEditBar1, Me.mnuItemSetExperimentBlock, Me.mnuItemRenumber, Me.mnuOptColWidth})
        Me.mnuItemEdit.Name = "mnuItemEdit"
        Me.mnuItemEdit.Size = New System.Drawing.Size(39, 20)
        Me.mnuItemEdit.Text = "&Edit"
        '
        'mnuItemUndo
        '
        Me.mnuItemUndo.Name = "mnuItemUndo"
        Me.mnuItemUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.mnuItemUndo.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemUndo.Text = "&Undo"
        '
        'mnuEditBar1
        '
        Me.mnuEditBar1.Name = "mnuEditBar1"
        Me.mnuEditBar1.Size = New System.Drawing.Size(270, 6)
        '
        'mnuItemCopy
        '
        Me.mnuItemCopy.Name = "mnuItemCopy"
        Me.mnuItemCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuItemCopy.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemCopy.Text = "Copy to Clipboard"
        '
        'mnuItemPaste
        '
        Me.mnuItemPaste.Name = "mnuItemPaste"
        Me.mnuItemPaste.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mnuItemPaste.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemPaste.Text = "Paste to Item List"
        '
        'mnuItemClearCells
        '
        Me.mnuItemClearCells.Name = "mnuItemClearCells"
        Me.mnuItemClearCells.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemClearCells.Text = "&Clear Items"
        '
        'mnuItemInsert
        '
        Me.mnuItemInsert.Name = "mnuItemInsert"
        Me.mnuItemInsert.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.mnuItemInsert.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemInsert.Text = "&Insert Item"
        '
        'mnuItemDuplicateBlock
        '
        Me.mnuItemDuplicateBlock.Name = "mnuItemDuplicateBlock"
        Me.mnuItemDuplicateBlock.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.mnuItemDuplicateBlock.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemDuplicateBlock.Text = "D&uplicate Items"
        '
        'mnuItemDel
        '
        Me.mnuItemDel.Name = "mnuItemDel"
        Me.mnuItemDel.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuItemDel.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemDel.Text = "&Remove Items"
        '
        'mnuItemShuffleBlock
        '
        Me.mnuItemShuffleBlock.Name = "mnuItemShuffleBlock"
        Me.mnuItemShuffleBlock.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemShuffleBlock.Text = "&Shuffle Items"
        '
        'mnuFillAutomatically
        '
        Me.mnuFillAutomatically.Name = "mnuFillAutomatically"
        Me.mnuFillAutomatically.Size = New System.Drawing.Size(273, 22)
        Me.mnuFillAutomatically.Text = "Fill automatically with numeric values"
        '
        'mnuItemEditBar1
        '
        Me.mnuItemEditBar1.Name = "mnuItemEditBar1"
        Me.mnuItemEditBar1.Size = New System.Drawing.Size(270, 6)
        '
        'mnuItemSetExperimentBlock
        '
        Me.mnuItemSetExperimentBlock.Name = "mnuItemSetExperimentBlock"
        Me.mnuItemSetExperimentBlock.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemSetExperimentBlock.Text = "Set Experiment Item Range"
        '
        'mnuItemRenumber
        '
        Me.mnuItemRenumber.Name = "mnuItemRenumber"
        Me.mnuItemRenumber.Size = New System.Drawing.Size(273, 22)
        Me.mnuItemRenumber.Text = "Renumber Index"
        '
        'mnuOptColWidth
        '
        Me.mnuOptColWidth.Name = "mnuOptColWidth"
        Me.mnuOptColWidth.Size = New System.Drawing.Size(273, 22)
        Me.mnuOptColWidth.Text = "Set Optimal Column Width"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewStimulus, Me.mnuSTIMLogList, Me.mnuRemoteMonitor, Me.mnuBar3, Me.mnuViewSettings, Me.mnuBar2, Me.mnuViewOptions})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(44, 20)
        Me.mnuView.Text = "&View"
        '
        'mnuViewStimulus
        '
        Me.mnuViewStimulus.Name = "mnuViewStimulus"
        Me.mnuViewStimulus.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F7), System.Windows.Forms.Keys)
        Me.mnuViewStimulus.Size = New System.Drawing.Size(266, 22)
        Me.mnuViewStimulus.Text = "Stimulus before &assembling"
        '
        'mnuSTIMLogList
        '
        Me.mnuSTIMLogList.Name = "mnuSTIMLogList"
        Me.mnuSTIMLogList.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.mnuSTIMLogList.Size = New System.Drawing.Size(266, 22)
        Me.mnuSTIMLogList.Text = "STIM log list"
        '
        'mnuRemoteMonitor
        '
        Me.mnuRemoteMonitor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRemoteMonitorConnect, Me.mnuRemoteMonitorGetSettings, Me.mnuRemoteMonitorGetItemlist, Me.mnuRemoteMonitorDisconnect, Me.mnuRemoteMonitorDisconnectAllClients, Me.mnuRemoteMonitorFollowCurrentItem, Me.mnuRemoteMonitorUpdateSettings})
        Me.mnuRemoteMonitor.Name = "mnuRemoteMonitor"
        Me.mnuRemoteMonitor.Size = New System.Drawing.Size(266, 22)
        Me.mnuRemoteMonitor.Text = "Remote Monitor"
        '
        'mnuRemoteMonitorConnect
        '
        Me.mnuRemoteMonitorConnect.Name = "mnuRemoteMonitorConnect"
        Me.mnuRemoteMonitorConnect.Size = New System.Drawing.Size(185, 22)
        Me.mnuRemoteMonitorConnect.Text = "Connect"
        '
        'mnuRemoteMonitorGetSettings
        '
        Me.mnuRemoteMonitorGetSettings.Enabled = False
        Me.mnuRemoteMonitorGetSettings.Name = "mnuRemoteMonitorGetSettings"
        Me.mnuRemoteMonitorGetSettings.Size = New System.Drawing.Size(185, 22)
        Me.mnuRemoteMonitorGetSettings.Text = "Get Settings"
        '
        'mnuRemoteMonitorGetItemlist
        '
        Me.mnuRemoteMonitorGetItemlist.Enabled = False
        Me.mnuRemoteMonitorGetItemlist.Name = "mnuRemoteMonitorGetItemlist"
        Me.mnuRemoteMonitorGetItemlist.Size = New System.Drawing.Size(185, 22)
        Me.mnuRemoteMonitorGetItemlist.Text = "Get Itemlist"
        '
        'mnuRemoteMonitorDisconnect
        '
        Me.mnuRemoteMonitorDisconnect.Enabled = False
        Me.mnuRemoteMonitorDisconnect.Name = "mnuRemoteMonitorDisconnect"
        Me.mnuRemoteMonitorDisconnect.Size = New System.Drawing.Size(185, 22)
        Me.mnuRemoteMonitorDisconnect.Text = "Disconnect"
        '
        'mnuRemoteMonitorDisconnectAllClients
        '
        Me.mnuRemoteMonitorDisconnectAllClients.Enabled = False
        Me.mnuRemoteMonitorDisconnectAllClients.Name = "mnuRemoteMonitorDisconnectAllClients"
        Me.mnuRemoteMonitorDisconnectAllClients.Size = New System.Drawing.Size(185, 22)
        Me.mnuRemoteMonitorDisconnectAllClients.Text = "Disconnect all clients"
        '
        'mnuRemoteMonitorFollowCurrentItem
        '
        Me.mnuRemoteMonitorFollowCurrentItem.Checked = True
        Me.mnuRemoteMonitorFollowCurrentItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuRemoteMonitorFollowCurrentItem.Enabled = False
        Me.mnuRemoteMonitorFollowCurrentItem.Name = "mnuRemoteMonitorFollowCurrentItem"
        Me.mnuRemoteMonitorFollowCurrentItem.Size = New System.Drawing.Size(185, 22)
        Me.mnuRemoteMonitorFollowCurrentItem.Text = "Follow current Item"
        '
        'mnuRemoteMonitorUpdateSettings
        '
        Me.mnuRemoteMonitorUpdateSettings.Checked = True
        Me.mnuRemoteMonitorUpdateSettings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuRemoteMonitorUpdateSettings.Enabled = False
        Me.mnuRemoteMonitorUpdateSettings.Name = "mnuRemoteMonitorUpdateSettings"
        Me.mnuRemoteMonitorUpdateSettings.Size = New System.Drawing.Size(185, 22)
        Me.mnuRemoteMonitorUpdateSettings.Text = "Update settings"
        '
        'mnuBar3
        '
        Me.mnuBar3.Name = "mnuBar3"
        Me.mnuBar3.Size = New System.Drawing.Size(263, 6)
        '
        'mnuViewSettings
        '
        Me.mnuViewSettings.Name = "mnuViewSettings"
        Me.mnuViewSettings.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.mnuViewSettings.Size = New System.Drawing.Size(266, 22)
        Me.mnuViewSettings.Text = "&Settings..."
        '
        'mnuBar2
        '
        Me.mnuBar2.Name = "mnuBar2"
        Me.mnuBar2.Size = New System.Drawing.Size(263, 6)
        '
        'mnuViewOptions
        '
        Me.mnuViewOptions.Name = "mnuViewOptions"
        Me.mnuViewOptions.Size = New System.Drawing.Size(266, 22)
        Me.mnuViewOptions.Text = "&Options..."
        '
        'mnuExp
        '
        Me.mnuExp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConnectOutput, Me.mnuItemStimulateSelected, Me.mnuBarRun1, Me.mnuStartExp, Me.mnuStartExpAtItem, Me.mnuExpContinue, Me.mnuBarRun2, Me.mnuSnapshot, Me.mnuLevelDancer})
        Me.mnuExp.Name = "mnuExp"
        Me.mnuExp.Size = New System.Drawing.Size(40, 20)
        Me.mnuExp.Text = "&Run"
        '
        'mnuConnectOutput
        '
        Me.mnuConnectOutput.Name = "mnuConnectOutput"
        Me.mnuConnectOutput.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuConnectOutput.Size = New System.Drawing.Size(247, 22)
        Me.mnuConnectOutput.Text = "&Connect"
        '
        'mnuItemStimulateSelected
        '
        Me.mnuItemStimulateSelected.Name = "mnuItemStimulateSelected"
        Me.mnuItemStimulateSelected.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.mnuItemStimulateSelected.Size = New System.Drawing.Size(247, 22)
        Me.mnuItemStimulateSelected.Text = "Stimulate Selected Item"
        '
        'mnuBarRun1
        '
        Me.mnuBarRun1.Name = "mnuBarRun1"
        Me.mnuBarRun1.Size = New System.Drawing.Size(244, 6)
        '
        'mnuStartExp
        '
        Me.mnuStartExp.Name = "mnuStartExp"
        Me.mnuStartExp.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.mnuStartExp.Size = New System.Drawing.Size(247, 22)
        Me.mnuStartExp.Text = "S&tart Experiment"
        '
        'mnuStartExpAtItem
        '
        Me.mnuStartExpAtItem.Name = "mnuStartExpAtItem"
        Me.mnuStartExpAtItem.Size = New System.Drawing.Size(247, 22)
        Me.mnuStartExpAtItem.Text = "Start Experiment at selected item"
        '
        'mnuExpContinue
        '
        Me.mnuExpContinue.Name = "mnuExpContinue"
        Me.mnuExpContinue.Size = New System.Drawing.Size(247, 22)
        Me.mnuExpContinue.Text = "Continue Experiment"
        '
        'mnuBarRun2
        '
        Me.mnuBarRun2.Name = "mnuBarRun2"
        Me.mnuBarRun2.Size = New System.Drawing.Size(244, 6)
        '
        'mnuSnapshot
        '
        Me.mnuSnapshot.Name = "mnuSnapshot"
        Me.mnuSnapshot.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.mnuSnapshot.Size = New System.Drawing.Size(247, 22)
        Me.mnuSnapshot.Text = "Sna&pshot settings to log file"
        '
        'mnuLevelDancer
        '
        Me.mnuLevelDancer.Name = "mnuLevelDancer"
        Me.mnuLevelDancer.Size = New System.Drawing.Size(247, 22)
        Me.mnuLevelDancer.Text = "Level Dancer"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpShortcuts, Me.FlagsToolStripMenuItem, Me.mnuCheckForUpdates, Me.mnuExpSuiteOnSourceforge, Me.OpenDocumentationFolderToolStripMenuItem, Me.HistoryToolStripMenuItem, Me.CreditsToolStripMenuItem, Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuHelpShortcuts
        '
        Me.mnuHelpShortcuts.Name = "mnuHelpShortcuts"
        Me.mnuHelpShortcuts.Size = New System.Drawing.Size(225, 22)
        Me.mnuHelpShortcuts.Text = "&Shortcuts"
        Me.mnuHelpShortcuts.ToolTipText = "Shortcuts in application"
        '
        'FlagsToolStripMenuItem
        '
        Me.FlagsToolStripMenuItem.Name = "FlagsToolStripMenuItem"
        Me.FlagsToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.FlagsToolStripMenuItem.Text = "Flags"
        Me.FlagsToolStripMenuItem.ToolTipText = "Supported flag parameters when launching application in command window or with ba" &
    "tch file"
        '
        'mnuCheckForUpdates
        '
        Me.mnuCheckForUpdates.Name = "mnuCheckForUpdates"
        Me.mnuCheckForUpdates.Size = New System.Drawing.Size(225, 22)
        Me.mnuCheckForUpdates.Text = "Check for Updates"
        Me.mnuCheckForUpdates.ToolTipText = "Check if local update server is available, otherwise check for updates on Sourcef" &
    "orge.net"
        '
        'mnuExpSuiteOnSourceforge
        '
        Me.mnuExpSuiteOnSourceforge.Name = "mnuExpSuiteOnSourceforge"
        Me.mnuExpSuiteOnSourceforge.Size = New System.Drawing.Size(225, 22)
        Me.mnuExpSuiteOnSourceforge.Text = "ExpSuite on Sourceforge.net"
        Me.mnuExpSuiteOnSourceforge.ToolTipText = "Visit https://sourceforge.net/projects/expsuite/"
        '
        'OpenDocumentationFolderToolStripMenuItem
        '
        Me.OpenDocumentationFolderToolStripMenuItem.Name = "OpenDocumentationFolderToolStripMenuItem"
        Me.OpenDocumentationFolderToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.OpenDocumentationFolderToolStripMenuItem.Text = "Open Documentation Folder"
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplicationHistoryToolStripMenuItem, Me.FWHistoryToolStripMenuItem})
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'ApplicationHistoryToolStripMenuItem
        '
        Me.ApplicationHistoryToolStripMenuItem.Name = "ApplicationHistoryToolStripMenuItem"
        Me.ApplicationHistoryToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ApplicationHistoryToolStripMenuItem.Text = "Application History"
        Me.ApplicationHistoryToolStripMenuItem.ToolTipText = "Open application history in Editor"
        '
        'FWHistoryToolStripMenuItem
        '
        Me.FWHistoryToolStripMenuItem.Name = "FWHistoryToolStripMenuItem"
        Me.FWHistoryToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.FWHistoryToolStripMenuItem.Text = "FW History"
        Me.FWHistoryToolStripMenuItem.ToolTipText = "Open FrameWork history in Editor"
        '
        'CreditsToolStripMenuItem
        '
        Me.CreditsToolStripMenuItem.Name = "CreditsToolStripMenuItem"
        Me.CreditsToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CreditsToolStripMenuItem.Text = "Credits"
        Me.CreditsToolStripMenuItem.ToolTipText = "Developers and contributors list"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnuHelpAbout.Size = New System.Drawing.Size(225, 22)
        Me.mnuHelpAbout.Text = "&About "
        Me.mnuHelpAbout.ToolTipText = "About this application"
        '
        'lstLog
        '
        Me.lstLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstLog.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.Location = New System.Drawing.Point(332, 3)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(532, 95)
        Me.lstLog.TabIndex = 62
        Me.lstLog.Visible = False
        '
        'PanelBottom
        '
        Me.PanelBottom.Controls.Add(Me.cmdSanityCheck)
        Me.PanelBottom.Controls.Add(Me.cmdInitialCheck)
        Me.PanelBottom.Controls.Add(Me.cmdShowPlots)
        Me.PanelBottom.Controls.Add(Me.cmdInitButton)
        Me.PanelBottom.Controls.Add(Me.GroupBox2)
        Me.PanelBottom.Controls.Add(Me.GroupBox1)
        Me.PanelBottom.Controls.Add(Me.cmdItemCreateList)
        Me.PanelBottom.Controls.Add(Me.Label5)
        Me.PanelBottom.Controls.Add(Me.cmdItemShuffleList)
        Me.PanelBottom.Controls.Add(Me.cmbResult)
        Me.PanelBottom.Controls.Add(Me.cmdItemSortList)
        Me.PanelBottom.Controls.Add(Me.lblTTShow)
        Me.PanelBottom.Controls.Add(Me.cmdCreateAllStimuli)
        Me.PanelBottom.Controls.Add(Me.cmdItemAddRepetition)
        Me.PanelBottom.Controls.Add(Me.cmdItemStimulateSelected)
        Me.PanelBottom.Controls.Add(Me.cmdItemStimulateAll)
        Me.PanelBottom.Controls.Add(Me.cmdExpShow)
        Me.PanelBottom.Controls.Add(Me.cmdItemLogList)
        Me.PanelBottom.Controls.Add(Me.cmdExpHide)
        Me.PanelBottom.Controls.Add(Me.cmdStartExp)
        Me.PanelBottom.Controls.Add(Me.pbStatus)
        Me.PanelBottom.Controls.Add(Me.chkExpRun)
        Me.PanelBottom.Controls.Add(Me.cmdCancel)
        Me.PanelBottom.Controls.Add(Me.cmdResultExecute)
        Me.PanelBottom.Controls.Add(Me.cmdGenerateSOFA)
        Me.PanelBottom.Controls.Add(Me.cmdContinueExp)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 426)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(876, 237)
        Me.PanelBottom.TabIndex = 58
        '
        'cmdSanityCheck
        '
        Me.cmdSanityCheck.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdSanityCheck.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSanityCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSanityCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSanityCheck.Image = Global.ExpSuite.My.Resources.Resources.tick_transparent
        Me.cmdSanityCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSanityCheck.Location = New System.Drawing.Point(454, 27)
        Me.cmdSanityCheck.Name = "cmdSanityCheck"
        Me.cmdSanityCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSanityCheck.Size = New System.Drawing.Size(117, 50)
        Me.cmdSanityCheck.TabIndex = 64
        Me.cmdSanityCheck.Text = "Run validation"
        Me.cmdSanityCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSanityCheck.UseVisualStyleBackColor = False
        '
        'cmdInitialCheck
        '
        Me.cmdInitialCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdInitialCheck.BackColor = System.Drawing.SystemColors.Control
        Me.cmdInitialCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdInitialCheck.Enabled = False
        Me.cmdInitialCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdInitialCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdInitialCheck.Location = New System.Drawing.Point(659, 164)
        Me.cmdInitialCheck.Name = "cmdInitialCheck"
        Me.cmdInitialCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdInitialCheck.Size = New System.Drawing.Size(70, 35)
        Me.cmdInitialCheck.TabIndex = 63
        Me.cmdInitialCheck.Text = "Initial check"
        Me.cmdInitialCheck.UseVisualStyleBackColor = False
        Me.cmdInitialCheck.Visible = False
        '
        'cmdShowPlots
        '
        Me.cmdShowPlots.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdShowPlots.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowPlots.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowPlots.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowPlots.Image = Global.ExpSuite.My.Resources.Resources.plot_icon
        Me.cmdShowPlots.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdShowPlots.Location = New System.Drawing.Point(454, 83)
        Me.cmdShowPlots.Name = "cmdShowPlots"
        Me.cmdShowPlots.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowPlots.Size = New System.Drawing.Size(117, 50)
        Me.cmdShowPlots.TabIndex = 62
        Me.cmdShowPlots.Text = "Plot selected HRTFs"
        Me.cmdShowPlots.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdShowPlots.UseVisualStyleBackColor = False
        '
        'cmdInitButton
        '
        Me.cmdInitButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdInitButton.BackColor = System.Drawing.SystemColors.Control
        Me.cmdInitButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdInitButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdInitButton.Image = Global.ExpSuite.My.Resources.Resources.crosshair_transparent
        Me.cmdInitButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdInitButton.Location = New System.Drawing.Point(327, 27)
        Me.cmdInitButton.Name = "cmdInitButton"
        Me.cmdInitButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdInitButton.Size = New System.Drawing.Size(118, 50)
        Me.cmdInitButton.TabIndex = 60
        Me.cmdInitButton.Text = "Calibrate tracker"
        Me.cmdInitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdInitButton.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSetTo0)
        Me.GroupBox2.Controls.Add(Me.cmdTTsendTo0)
        Me.GroupBox2.Controls.Add(Me.labelTTaz)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.labelTTcalibrated)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.cmdTTShow)
        Me.GroupBox2.Location = New System.Drawing.Point(78, 128)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(184, 79)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Turntable"
        '
        'cmdSetTo0
        '
        Me.cmdSetTo0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSetTo0.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSetTo0.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSetTo0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSetTo0.Location = New System.Drawing.Point(106, 44)
        Me.cmdSetTo0.Name = "cmdSetTo0"
        Me.cmdSetTo0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSetTo0.Size = New System.Drawing.Size(66, 21)
        Me.cmdSetTo0.TabIndex = 52
        Me.cmdSetTo0.Text = "Set to 0°"
        Me.cmdSetTo0.UseVisualStyleBackColor = False
        '
        'cmdTTsendTo0
        '
        Me.cmdTTsendTo0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTTsendTo0.BackColor = System.Drawing.SystemColors.Control
        Me.cmdTTsendTo0.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdTTsendTo0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTTsendTo0.Location = New System.Drawing.Point(106, 18)
        Me.cmdTTsendTo0.Name = "cmdTTsendTo0"
        Me.cmdTTsendTo0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdTTsendTo0.Size = New System.Drawing.Size(66, 21)
        Me.cmdTTsendTo0.TabIndex = 51
        Me.cmdTTsendTo0.Text = "Send to 0°"
        Me.cmdTTsendTo0.UseVisualStyleBackColor = False
        '
        'labelTTaz
        '
        Me.labelTTaz.BackColor = System.Drawing.Color.Lime
        Me.labelTTaz.Location = New System.Drawing.Point(59, 19)
        Me.labelTTaz.Margin = New System.Windows.Forms.Padding(2)
        Me.labelTTaz.Name = "labelTTaz"
        Me.labelTTaz.ReadOnly = True
        Me.labelTTaz.Size = New System.Drawing.Size(37, 20)
        Me.labelTTaz.TabIndex = 19
        Me.labelTTaz.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 20)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Azim. (°):"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelTTcalibrated
        '
        Me.labelTTcalibrated.BackColor = System.Drawing.Color.Lime
        Me.labelTTcalibrated.Location = New System.Drawing.Point(55, 19)
        Me.labelTTcalibrated.Margin = New System.Windows.Forms.Padding(2)
        Me.labelTTcalibrated.Name = "labelTTcalibrated"
        Me.labelTTcalibrated.ReadOnly = True
        Me.labelTTcalibrated.Size = New System.Drawing.Size(37, 20)
        Me.labelTTcalibrated.TabIndex = 17
        Me.labelTTcalibrated.Text = "Yes"
        Me.labelTTcalibrated.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 20)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Initialised:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label15.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.labelNcams)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.labelTrackingYesNo)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.labelZ)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.labelY)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.labelX)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.labelRoll)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.labelPitch)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.labelYaw)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(77, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(186, 113)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tracker"
        '
        'labelNcams
        '
        Me.labelNcams.BackColor = System.Drawing.Color.Red
        Me.labelNcams.Location = New System.Drawing.Point(144, 20)
        Me.labelNcams.Margin = New System.Windows.Forms.Padding(2)
        Me.labelNcams.Name = "labelNcams"
        Me.labelNcams.ReadOnly = True
        Me.labelNcams.Size = New System.Drawing.Size(37, 20)
        Me.labelNcams.TabIndex = 15
        Me.labelNcams.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(101, 21)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "# cams:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelTrackingYesNo
        '
        Me.labelTrackingYesNo.BackColor = System.Drawing.Color.Red
        Me.labelTrackingYesNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTrackingYesNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labelTrackingYesNo.Location = New System.Drawing.Point(55, 20)
        Me.labelTrackingYesNo.Margin = New System.Windows.Forms.Padding(2)
        Me.labelTrackingYesNo.Name = "labelTrackingYesNo"
        Me.labelTrackingYesNo.ReadOnly = True
        Me.labelTrackingYesNo.Size = New System.Drawing.Size(37, 19)
        Me.labelTrackingYesNo.TabIndex = 13
        Me.labelTrackingYesNo.Text = "No"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 21)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Visible:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelZ
        '
        Me.labelZ.Location = New System.Drawing.Point(144, 88)
        Me.labelZ.Margin = New System.Windows.Forms.Padding(2)
        Me.labelZ.Name = "labelZ"
        Me.labelZ.ReadOnly = True
        Me.labelZ.Size = New System.Drawing.Size(37, 20)
        Me.labelZ.TabIndex = 11
        Me.labelZ.Text = "0.0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(104, 90)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Z (cm):"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelY
        '
        Me.labelY.Location = New System.Drawing.Point(144, 65)
        Me.labelY.Margin = New System.Windows.Forms.Padding(2)
        Me.labelY.Name = "labelY"
        Me.labelY.ReadOnly = True
        Me.labelY.Size = New System.Drawing.Size(37, 20)
        Me.labelY.TabIndex = 9
        Me.labelY.Text = "0.0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(104, 67)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Y (cm):"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelX
        '
        Me.labelX.Location = New System.Drawing.Point(144, 43)
        Me.labelX.Margin = New System.Windows.Forms.Padding(2)
        Me.labelX.Name = "labelX"
        Me.labelX.ReadOnly = True
        Me.labelX.Size = New System.Drawing.Size(37, 20)
        Me.labelX.TabIndex = 7
        Me.labelX.Text = "0.0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(104, 43)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "X (cm):"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelRoll
        '
        Me.labelRoll.Location = New System.Drawing.Point(55, 88)
        Me.labelRoll.Margin = New System.Windows.Forms.Padding(2)
        Me.labelRoll.Name = "labelRoll"
        Me.labelRoll.ReadOnly = True
        Me.labelRoll.Size = New System.Drawing.Size(37, 20)
        Me.labelRoll.TabIndex = 5
        Me.labelRoll.Text = "0.0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 89)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Roll (°):"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelPitch
        '
        Me.labelPitch.Location = New System.Drawing.Point(55, 65)
        Me.labelPitch.Margin = New System.Windows.Forms.Padding(2)
        Me.labelPitch.Name = "labelPitch"
        Me.labelPitch.ReadOnly = True
        Me.labelPitch.Size = New System.Drawing.Size(37, 20)
        Me.labelPitch.TabIndex = 3
        Me.labelPitch.Text = "0.0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 67)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Pitch (°):"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelYaw
        '
        Me.labelYaw.Location = New System.Drawing.Point(55, 42)
        Me.labelYaw.Margin = New System.Windows.Forms.Padding(2)
        Me.labelYaw.Name = "labelYaw"
        Me.labelYaw.ReadOnly = True
        Me.labelYaw.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.labelYaw.Size = New System.Drawing.Size(37, 20)
        Me.labelYaw.TabIndex = 1
        Me.labelYaw.Text = "0.0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Yaw (°):"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTTShow
        '
        Me.lblTTShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTTShow.BackColor = System.Drawing.SystemColors.Control
        Me.lblTTShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTTShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTTShow.Location = New System.Drawing.Point(29, 191)
        Me.lblTTShow.Name = "lblTTShow"
        Me.lblTTShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTTShow.Size = New System.Drawing.Size(105, 13)
        Me.lblTTShow.TabIndex = 51
        Me.lblTTShow.Text = "Turntable:"
        Me.lblTTShow.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdGenerateSOFA
        '
        Me.cmdGenerateSOFA.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdGenerateSOFA.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGenerateSOFA.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGenerateSOFA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGenerateSOFA.Image = Global.ExpSuite.My.Resources.Resources.flag_transparent1
        Me.cmdGenerateSOFA.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdGenerateSOFA.Location = New System.Drawing.Point(454, 140)
        Me.cmdGenerateSOFA.Name = "cmdGenerateSOFA"
        Me.cmdGenerateSOFA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGenerateSOFA.Size = New System.Drawing.Size(117, 50)
        Me.cmdGenerateSOFA.TabIndex = 61
        Me.cmdGenerateSOFA.Text = "Generate SOFA files"
        Me.cmdGenerateSOFA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdGenerateSOFA.UseVisualStyleBackColor = False
        '
        'cmdContinueExp
        '
        Me.cmdContinueExp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdContinueExp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdContinueExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdContinueExp.Enabled = False
        Me.cmdContinueExp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdContinueExp.Image = CType(resources.GetObject("cmdContinueExp.Image"), System.Drawing.Image)
        Me.cmdContinueExp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdContinueExp.Location = New System.Drawing.Point(453, 140)
        Me.cmdContinueExp.Name = "cmdContinueExp"
        Me.cmdContinueExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdContinueExp.Size = New System.Drawing.Size(118, 50)
        Me.cmdContinueExp.TabIndex = 56
        Me.cmdContinueExp.Text = "Continue Experiment"
        Me.cmdContinueExp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdContinueExp.UseVisualStyleBackColor = False
        Me.cmdContinueExp.Visible = False
        '
        'PanelTop
        '
        Me.PanelTop.AutoSize = True
        Me.PanelTop.Controls.Add(Me.lstStatus)
        Me.PanelTop.Controls.Add(Me.lstLog)
        Me.PanelTop.Controls.Add(Me.PanelGeneral)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 49)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(876, 103)
        Me.PanelTop.TabIndex = 63
        '
        'PanelGeneral
        '
        Me.PanelGeneral.Controls.Add(Me.lblWorkDir)
        Me.PanelGeneral.Controls.Add(Me.lblRootDir)
        Me.PanelGeneral.Controls.Add(Me.lblStimOutput)
        Me.PanelGeneral.Controls.Add(Me.Label7)
        Me.PanelGeneral.Controls.Add(Me.Label6)
        Me.PanelGeneral.Controls.Add(Me.lblExpType)
        Me.PanelGeneral.Controls.Add(Me.Label4)
        Me.PanelGeneral.Controls.Add(Me.Label8)
        Me.PanelGeneral.Location = New System.Drawing.Point(0, 0)
        Me.PanelGeneral.MinimumSize = New System.Drawing.Size(293, 100)
        Me.PanelGeneral.Name = "PanelGeneral"
        Me.PanelGeneral.Size = New System.Drawing.Size(333, 100)
        Me.PanelGeneral.TabIndex = 61
        '
        'PanelItemList
        '
        Me.PanelItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelItemList.Controls.Add(Me.dgvItemList)
        Me.PanelItemList.Controls.Add(Me.PanelItemListRight)
        Me.PanelItemList.Controls.Add(Me.PanelItemListTop)
        Me.PanelItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelItemList.Location = New System.Drawing.Point(0, 152)
        Me.PanelItemList.Name = "PanelItemList"
        Me.PanelItemList.Size = New System.Drawing.Size(876, 274)
        Me.PanelItemList.TabIndex = 64
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AllowUserToOrderColumns = True
        Me.dgvItemList.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightYellow
        Me.dgvItemList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvItemList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvItemList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemList.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvItemList.Enabled = False
        Me.dgvItemList.Location = New System.Drawing.Point(0, 57)
        Me.dgvItemList.Name = "dgvItemList"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemList.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvItemList.RowHeadersWidth = 30
        Me.dgvItemList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItemList.Size = New System.Drawing.Size(815, 213)
        Me.dgvItemList.TabIndex = 57
        '
        'PanelItemListRight
        '
        Me.PanelItemListRight.Controls.Add(Me.cmdItemMoveBottom)
        Me.PanelItemListRight.Controls.Add(Me.cmdItemMoveTop)
        Me.PanelItemListRight.Controls.Add(Me.lblItemNr)
        Me.PanelItemListRight.Controls.Add(Me.cmdItemMoveUp)
        Me.PanelItemListRight.Controls.Add(Me.cmdItemMoveDown)
        Me.PanelItemListRight.Controls.Add(Me.cmdItemUndo)
        Me.PanelItemListRight.Controls.Add(Me.cmdItemDel)
        Me.PanelItemListRight.Controls.Add(Me.cmdItemInsert)
        Me.PanelItemListRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelItemListRight.Location = New System.Drawing.Point(815, 57)
        Me.PanelItemListRight.Name = "PanelItemListRight"
        Me.PanelItemListRight.Size = New System.Drawing.Size(57, 213)
        Me.PanelItemListRight.TabIndex = 60
        '
        'PanelItemListTop
        '
        Me.PanelItemListTop.Controls.Add(Me.Label1)
        Me.PanelItemListTop.Controls.Add(Me.lblItemList)
        Me.PanelItemListTop.Controls.Add(Me.cmdItemSet)
        Me.PanelItemListTop.Controls.Add(Me.txtSelItem)
        Me.PanelItemListTop.Controls.Add(Me.lblSelColumn)
        Me.PanelItemListTop.Controls.Add(Me.cmdItemBrowse)
        Me.PanelItemListTop.Controls.Add(Me.lblSelItemLabel)
        Me.PanelItemListTop.Controls.Add(Me.lblSelItemNr)
        Me.PanelItemListTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelItemListTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelItemListTop.Name = "PanelItemListTop"
        Me.PanelItemListTop.Size = New System.Drawing.Size(872, 57)
        Me.PanelItemListTop.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "File Name:"
        '
        'lblItemList
        '
        Me.lblItemList.AutoSize = True
        Me.lblItemList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItemList.Location = New System.Drawing.Point(85, 6)
        Me.lblItemList.Name = "lblItemList"
        Me.lblItemList.Size = New System.Drawing.Size(43, 13)
        Me.lblItemList.TabIndex = 57
        Me.lblItemList.Text = "ItemList"
        '
        'tmrTracker
        '
        Me.tmrTracker.Enabled = True
        Me.tmrTracker.Interval = 200
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 687)
        Me.Controls.Add(Me.PanelItemList)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.tbToolBar)
        Me.Controls.Add(Me.sbStatusBar)
        Me.Controls.Add(Me.lineToolbar)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(891, 674)
        Me.Name = "frmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.popupMenuStrip.ResumeLayout(False)
        Me.tbToolBar.ResumeLayout(False)
        Me.tbToolBar.PerformLayout()
        Me.sbStatusBar.ResumeLayout(False)
        Me.sbStatusBar.PerformLayout()
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.PanelBottom.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelGeneral.ResumeLayout(False)
        Me.PanelItemList.ResumeLayout(False)
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelItemListRight.ResumeLayout(False)
        Me.PanelItemListTop.ResumeLayout(False)
        Me.PanelItemListTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lstLog As System.Windows.Forms.ListBox
    Public WithEvents tbButtonNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents popupMenuStrip As System.Windows.Forms.ContextMenuStrip
    Public WithEvents ctxtmnuItemUndo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuItemCopy As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuItemClearCells As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuItemInsert As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuItemDuplicateBlock As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuItemDel As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuItemShuffleBlock As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuItemSetExperimentBlock As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuItemRenumber As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ctxtmnuOptColWidth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents mnuLevelDancer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents PanelItemList As System.Windows.Forms.Panel
    Friend WithEvents PanelItemListTop As System.Windows.Forms.Panel
    Friend WithEvents PanelItemListRight As System.Windows.Forms.Panel
    Friend WithEvents PanelGeneral As System.Windows.Forms.Panel
    Friend WithEvents lblItemList As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mnuExpContinue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemSetFresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemSetProcessing As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemSetFinishedOK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemSetFinishedWithErrors As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents cmdContinueExp As System.Windows.Forms.Button
    Public WithEvents cmdItemMoveTop As System.Windows.Forms.Button
    Public WithEvents cmdItemMoveBottom As System.Windows.Forms.Button
    Friend WithEvents ctxtmnuFillAutomatically As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFillAutomatically As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoteMonitorGetSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCheckForUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExpSuiteOnSourceforge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoteMonitorDisconnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoteMonitorGetItemlist As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoteMonitorFollowCurrentItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoteMonitorDisconnectAllClients As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoteMonitorUpdateSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoteMonitorConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreditsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApplicationHistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FWHistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenDocumentationFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IgnoredToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ctxtmnuItemPaste As ToolStripMenuItem
    Friend WithEvents mnuItemPaste As ToolStripMenuItem
    Public WithEvents cmdInitButton As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents labelTTaz As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents labelTTcalibrated As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents labelNcams As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents labelTrackingYesNo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents labelZ As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents labelY As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents labelX As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents labelRoll As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents labelPitch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents labelYaw As TextBox
    Friend WithEvents Label2 As Label
    Public WithEvents lblTTShow As Label
    Public WithEvents cmdGenerateSOFA As Button
    Friend WithEvents tmrTracker As Timer
    Public WithEvents cmdShowPlots As Button
    Public WithEvents cmdInitialCheck As Button
    Public WithEvents cmdSanityCheck As Button
    Public WithEvents cmdSetTo0 As Button
    Public WithEvents cmdTTsendTo0 As Button
#End Region
End Class