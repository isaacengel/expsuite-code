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
    Public WithEvents lblTTShow As System.Windows.Forms.Label
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.lblTTShow = New System.Windows.Forms.Label()
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
        Me.cmdCalibrateOptitrackSelected = New System.Windows.Forms.Button()
        Me.cmdContinueExp = New System.Windows.Forms.Button()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.PanelGeneral = New System.Windows.Forms.Panel()
        Me.PanelItemList = New System.Windows.Forms.Panel()
        Me.dgvItemList = New System.Windows.Forms.DataGridView()
        Me.PanelItemListRight = New System.Windows.Forms.Panel()
        Me.PanelItemListTop = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblItemList = New System.Windows.Forms.Label()
        Me.popupMenuStrip.SuspendLayout()
        Me.tbToolBar.SuspendLayout()
        Me.sbStatusBar.SuspendLayout()
        Me.MainMenu1.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
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
        Me.lstStatus.Size = New System.Drawing.Size(313, 95)
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
        Me.cmbResult.Location = New System.Drawing.Point(437, 53)
        Me.cmbResult.Name = "cmbResult"
        Me.cmbResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbResult.Size = New System.Drawing.Size(207, 95)
        Me.cmbResult.TabIndex = 55
        '
        'cmdTTShow
        '
        Me.cmdTTShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTTShow.BackColor = System.Drawing.SystemColors.Control
        Me.cmdTTShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdTTShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTTShow.Location = New System.Drawing.Point(551, 29)
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
        Me.chkExpRun.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkExpRun.Location = New System.Drawing.Point(307, 130)
        Me.chkExpRun.Name = "chkExpRun"
        Me.chkExpRun.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkExpRun.Size = New System.Drawing.Size(109, 24)
        Me.chkExpRun.TabIndex = 41
        Me.chkExpRun.Text = "Run Experiment"
        Me.chkExpRun.UseVisualStyleBackColor = False
        '
        'cmdItemStimulateAll
        '
        Me.cmdItemStimulateAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemStimulateAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemStimulateAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemStimulateAll.Location = New System.Drawing.Point(29, 65)
        Me.cmdItemStimulateAll.Name = "cmdItemStimulateAll"
        Me.cmdItemStimulateAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemStimulateAll.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemStimulateAll.TabIndex = 3
        Me.cmdItemStimulateAll.Text = "Stimulate All"
        Me.cmdItemStimulateAll.UseVisualStyleBackColor = False
        '
        'cmdResultExecute
        '
        Me.cmdResultExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdResultExecute.BackColor = System.Drawing.SystemColors.Control
        Me.cmdResultExecute.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdResultExecute.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdResultExecute.Location = New System.Drawing.Point(477, 151)
        Me.cmdResultExecute.Name = "cmdResultExecute"
        Me.cmdResultExecute.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdResultExecute.Size = New System.Drawing.Size(129, 41)
        Me.cmdResultExecute.TabIndex = 11
        Me.cmdResultExecute.Text = "Execute"
        Me.cmdResultExecute.UseVisualStyleBackColor = False
        '
        'cmdItemSortList
        '
        Me.cmdItemSortList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemSortList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemSortList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemSortList.Location = New System.Drawing.Point(29, 137)
        Me.cmdItemSortList.Name = "cmdItemSortList"
        Me.cmdItemSortList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemSortList.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemSortList.TabIndex = 6
        Me.cmdItemSortList.Text = "Sort List"
        Me.cmdItemSortList.UseVisualStyleBackColor = False
        '
        'cmdItemShuffleList
        '
        Me.cmdItemShuffleList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemShuffleList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemShuffleList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemShuffleList.Location = New System.Drawing.Point(29, 113)
        Me.cmdItemShuffleList.Name = "cmdItemShuffleList"
        Me.cmdItemShuffleList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemShuffleList.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemShuffleList.TabIndex = 5
        Me.cmdItemShuffleList.Text = "Shuffle List"
        Me.cmdItemShuffleList.UseVisualStyleBackColor = False
        '
        'cmdItemCreateList
        '
        Me.cmdItemCreateList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemCreateList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemCreateList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemCreateList.Location = New System.Drawing.Point(29, 17)
        Me.cmdItemCreateList.Name = "cmdItemCreateList"
        Me.cmdItemCreateList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemCreateList.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemCreateList.TabIndex = 1
        Me.cmdItemCreateList.Text = "Create List"
        Me.cmdItemCreateList.UseVisualStyleBackColor = False
        '
        'cmdCreateAllStimuli
        '
        Me.cmdCreateAllStimuli.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCreateAllStimuli.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCreateAllStimuli.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCreateAllStimuli.Location = New System.Drawing.Point(29, 41)
        Me.cmdCreateAllStimuli.Name = "cmdCreateAllStimuli"
        Me.cmdCreateAllStimuli.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCreateAllStimuli.Size = New System.Drawing.Size(101, 21)
        Me.cmdCreateAllStimuli.TabIndex = 2
        Me.cmdCreateAllStimuli.Text = "Create All Stimuli"
        Me.cmdCreateAllStimuli.UseVisualStyleBackColor = False
        '
        'cmdItemAddRepetition
        '
        Me.cmdItemAddRepetition.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemAddRepetition.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemAddRepetition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemAddRepetition.Location = New System.Drawing.Point(29, 89)
        Me.cmdItemAddRepetition.Name = "cmdItemAddRepetition"
        Me.cmdItemAddRepetition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemAddRepetition.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemAddRepetition.TabIndex = 4
        Me.cmdItemAddRepetition.Text = "Add Repetition"
        Me.cmdItemAddRepetition.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCancel.Location = New System.Drawing.Point(153, 74)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(129, 50)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdItemLogList
        '
        Me.cmdItemLogList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemLogList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemLogList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemLogList.Location = New System.Drawing.Point(29, 161)
        Me.cmdItemLogList.Name = "cmdItemLogList"
        Me.cmdItemLogList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemLogList.Size = New System.Drawing.Size(101, 21)
        Me.cmdItemLogList.TabIndex = 7
        Me.cmdItemLogList.Text = "Log List"
        Me.cmdItemLogList.UseVisualStyleBackColor = False
        '
        'cmdStartExp
        '
        Me.cmdStartExp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdStartExp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStartExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStartExp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStartExp.Image = CType(resources.GetObject("cmdStartExp.Image"), System.Drawing.Image)
        Me.cmdStartExp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdStartExp.Location = New System.Drawing.Point(293, 17)
        Me.cmdStartExp.Name = "cmdStartExp"
        Me.cmdStartExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStartExp.Size = New System.Drawing.Size(129, 50)
        Me.cmdStartExp.TabIndex = 9
        Me.cmdStartExp.Text = "Start Experiment"
        Me.cmdStartExp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStartExp.UseVisualStyleBackColor = False
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
        Me.cmdExpHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpHide.Location = New System.Drawing.Point(597, 5)
        Me.cmdExpHide.Name = "cmdExpHide"
        Me.cmdExpHide.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpHide.Size = New System.Drawing.Size(42, 21)
        Me.cmdExpHide.TabIndex = 16
        Me.cmdExpHide.Text = "Hide"
        Me.cmdExpHide.UseVisualStyleBackColor = False
        '
        'cmdExpShow
        '
        Me.cmdExpShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExpShow.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExpShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpShow.Location = New System.Drawing.Point(551, 5)
        Me.cmdExpShow.Name = "cmdExpShow"
        Me.cmdExpShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpShow.Size = New System.Drawing.Size(42, 21)
        Me.cmdExpShow.TabIndex = 15
        Me.cmdExpShow.Text = "Show"
        Me.cmdExpShow.UseVisualStyleBackColor = False
        '
        'cmdItemStimulateSelected
        '
        Me.cmdItemStimulateSelected.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdItemStimulateSelected.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItemStimulateSelected.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItemStimulateSelected.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItemStimulateSelected.Image = CType(resources.GetObject("cmdItemStimulateSelected.Image"), System.Drawing.Image)
        Me.cmdItemStimulateSelected.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdItemStimulateSelected.Location = New System.Drawing.Point(153, 17)
        Me.cmdItemStimulateSelected.Name = "cmdItemStimulateSelected"
        Me.cmdItemStimulateSelected.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItemStimulateSelected.Size = New System.Drawing.Size(129, 50)
        Me.cmdItemStimulateSelected.TabIndex = 8
        Me.cmdItemStimulateSelected.Text = "Stimulate Selected"
        Me.cmdItemStimulateSelected.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdItemStimulateSelected.UseVisualStyleBackColor = False
        '
        'pbStatus
        '
        Me.pbStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStatus.Location = New System.Drawing.Point(0, 203)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(657, 24)
        Me.pbStatus.TabIndex = 27
        '
        'lblTTShow
        '
        Me.lblTTShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTTShow.BackColor = System.Drawing.SystemColors.Control
        Me.lblTTShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTTShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTTShow.Location = New System.Drawing.Point(438, 33)
        Me.lblTTShow.Name = "lblTTShow"
        Me.lblTTShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTTShow.Size = New System.Drawing.Size(105, 13)
        Me.lblTTShow.TabIndex = 51
        Me.lblTTShow.Text = "Turntable:"
        Me.lblTTShow.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(437, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(110, 17)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Experiment Screen:"
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
        Me.lblItemNr.Location = New System.Drawing.Point(0, 246)
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
        Me.tbToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbButtonNew, Me.tbButtonLoad, Me.tbButtonSaveAs, Me.ToolStripSeparator1, Me.tbButtonLoadItemList, Me.tbButtonSaveItemList, Me.ToolStripSeparator2, Me.tbButtonSettings, Me.tbButtonOptions, Me.ToolStripSeparator4, Me.tbButtonConnect, Me.ToolStripSeparator3, Me.tbButtonShowStimulus, Me.tbButtonSnapshot})
        Me.tbToolBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tbToolBar.Location = New System.Drawing.Point(0, 24)
        Me.tbToolBar.Name = "tbToolBar"
        Me.tbToolBar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbToolBar.Size = New System.Drawing.Size(657, 25)
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
        Me.sbStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._sbStatusBar_Panel0, Me._sbStatusBar_Panel1, Me._sbStatusBar_Panel2, Me._sbStatusBar_Panel3, Me._sbStatusBar_Panel4, Me._sbStatusBar_Panel5})
        Me.sbStatusBar.Location = New System.Drawing.Point(0, 711)
        Me.sbStatusBar.Name = "sbStatusBar"
        Me.sbStatusBar.Size = New System.Drawing.Size(657, 22)
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
        Me._sbStatusBar_Panel0.Size = New System.Drawing.Size(231, 22)
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
        Me._sbStatusBar_Panel1.Size = New System.Drawing.Size(96, 22)
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
        Me._sbStatusBar_Panel2.Size = New System.Drawing.Size(96, 22)
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
        Me._sbStatusBar_Panel3.Size = New System.Drawing.Size(73, 22)
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
        Me._sbStatusBar_Panel4.Size = New System.Drawing.Size(73, 22)
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
        Me._sbStatusBar_Panel5.Size = New System.Drawing.Size(73, 22)
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
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuItemEdit, Me.mnuView, Me.mnuExp, Me.mnuHelp})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(657, 24)
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
        Me.lstLog.Size = New System.Drawing.Size(313, 95)
        Me.lstLog.TabIndex = 62
        Me.lstLog.Visible = False
        '
        'PanelBottom
        '
        Me.PanelBottom.Controls.Add(Me.cmdCalibrateOptitrackSelected)
        Me.PanelBottom.Controls.Add(Me.cmdContinueExp)
        Me.PanelBottom.Controls.Add(Me.cmdItemCreateList)
        Me.PanelBottom.Controls.Add(Me.Label5)
        Me.PanelBottom.Controls.Add(Me.cmdItemShuffleList)
        Me.PanelBottom.Controls.Add(Me.cmbResult)
        Me.PanelBottom.Controls.Add(Me.cmdItemSortList)
        Me.PanelBottom.Controls.Add(Me.lblTTShow)
        Me.PanelBottom.Controls.Add(Me.cmdCreateAllStimuli)
        Me.PanelBottom.Controls.Add(Me.cmdTTShow)
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
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 484)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(657, 227)
        Me.PanelBottom.TabIndex = 58
        '
        'cmdCalibrateOptitrackSelected
        '
        Me.cmdCalibrateOptitrackSelected.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdCalibrateOptitrackSelected.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalibrateOptitrackSelected.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalibrateOptitrackSelected.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalibrateOptitrackSelected.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCalibrateOptitrackSelected.Location = New System.Drawing.Point(153, 132)
        Me.cmdCalibrateOptitrackSelected.Name = "cmdCalibrateOptitrackSelected"
        Me.cmdCalibrateOptitrackSelected.Size = New System.Drawing.Size(129, 31)
        Me.cmdCalibrateOptitrackSelected.TabIndex = 57
        Me.cmdCalibrateOptitrackSelected.Text = "Calibrate Optitrack"
        Me.cmdCalibrateOptitrackSelected.UseVisualStyleBackColor = False
        '
        'cmdContinueExp
        '
        Me.cmdContinueExp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdContinueExp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdContinueExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdContinueExp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdContinueExp.Image = CType(resources.GetObject("cmdContinueExp.Image"), System.Drawing.Image)
        Me.cmdContinueExp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdContinueExp.Location = New System.Drawing.Point(293, 74)
        Me.cmdContinueExp.Name = "cmdContinueExp"
        Me.cmdContinueExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdContinueExp.Size = New System.Drawing.Size(129, 50)
        Me.cmdContinueExp.TabIndex = 56
        Me.cmdContinueExp.Text = "Continue Experiment"
        Me.cmdContinueExp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdContinueExp.UseVisualStyleBackColor = False
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
        Me.PanelTop.Size = New System.Drawing.Size(657, 103)
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
        Me.PanelItemList.Size = New System.Drawing.Size(657, 332)
        Me.PanelItemList.TabIndex = 64
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AllowUserToOrderColumns = True
        Me.dgvItemList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        Me.dgvItemList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItemList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvItemList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvItemList.Enabled = False
        Me.dgvItemList.Location = New System.Drawing.Point(0, 57)
        Me.dgvItemList.Name = "dgvItemList"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemList.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItemList.RowHeadersWidth = 30
        Me.dgvItemList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItemList.Size = New System.Drawing.Size(596, 271)
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
        Me.PanelItemListRight.Location = New System.Drawing.Point(596, 57)
        Me.PanelItemListRight.Name = "PanelItemListRight"
        Me.PanelItemListRight.Size = New System.Drawing.Size(57, 271)
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
        Me.PanelItemListTop.Size = New System.Drawing.Size(653, 57)
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 733)
        Me.Controls.Add(Me.PanelItemList)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.tbToolBar)
        Me.Controls.Add(Me.sbStatusBar)
        Me.Controls.Add(Me.lineToolbar)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MinimumSize = New System.Drawing.Size(665, 760)
        Me.Name = "frmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.popupMenuStrip.ResumeLayout(false)
        Me.tbToolBar.ResumeLayout(false)
        Me.tbToolBar.PerformLayout
        Me.sbStatusBar.ResumeLayout(false)
        Me.sbStatusBar.PerformLayout
        Me.MainMenu1.ResumeLayout(false)
        Me.MainMenu1.PerformLayout
        Me.PanelBottom.ResumeLayout(false)
        Me.PanelTop.ResumeLayout(false)
        Me.PanelGeneral.ResumeLayout(false)
        Me.PanelItemList.ResumeLayout(false)
        CType(Me.dgvItemList,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelItemListRight.ResumeLayout(false)
        Me.PanelItemListTop.ResumeLayout(false)
        Me.PanelItemListTop.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

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
    Public WithEvents cmdCalibrateOptitrackSelected As Button
#End Region
End Class