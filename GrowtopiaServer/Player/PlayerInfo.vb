Imports GrowtopiaServer.Inventory

Public Class PlayerInfo
    Public isIn As Boolean = False
    Public netID As Integer
    Public haveGrowId As Boolean = False
    Public tankIDName As String = ""
    Public tankIDPass As String = ""
    Public requestedName As String = ""
    Public rawName As String = ""
    Public displayName As String = ""
    Public country As String = ""
    Public adminLevel As Integer = 0
    Public currentWorld As String = "EXIT"
    Public radio As Boolean = True
    Public x As Integer
    Public y As Integer
    Public isRotatedLeft As Boolean = False
    Public isUpdating As Boolean = False
    Public joinClothesUpdated As Boolean = False
    Public cloth_hair As Integer = 0
    Public cloth_shirt As Integer = 0
    Public cloth_pants As Integer = 0
    Public cloth_feet As Integer = 0
    Public cloth_face As Integer = 0
    Public cloth_hand As Integer = 0
    Public cloth_back As Integer = 0
    Public cloth_mask As Integer = 0
    Public cloth_necklace As Integer = 0
    Public canWalkInBlocks As Boolean = False
    Public canDoubleJump As Boolean = False
    Public isInvisible As Boolean = False
    Public noHands As Boolean = False
    Public noEyes As Boolean = False
    Public noBody As Boolean = False
    Public devilHorns As Boolean = False
    Public goldenHalo As Boolean = False
    Public isFrozen As Boolean = False
    Public isCursed As Boolean = False
    Public isDuctaped As Boolean = False
    Public haveCigar As Boolean = False
    Public isShining As Boolean = False
    Public isZombie As Boolean = False
    Public isHitByLava As Boolean = False
    Public haveHauntedShadows As Boolean = False
    Public haveGeigerRadiation As Boolean = False
    Public haveReflector As Boolean = False
    Public isEgged As Boolean = False
    Public havePineappleFloag As Boolean = False
    Public haveFlyingPineapple As Boolean = False
    Public haveSuperSupporterName As Boolean = False
    Public haveSupperPineapple As Boolean = False
    Public skinColor As Integer = &H8295C3FF
    Public inventory As PlayerInventory = New PlayerInventory()
    Public lastSB As Long = 0

End Class
