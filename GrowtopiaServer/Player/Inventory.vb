Public Class Inventory
    Public Structure InventoryItem
        Public itemID As Int16
        Public itemCount As Byte
    End Structure

    Public Class PlayerInventory
        Public items As InventoryItem() = New InventoryItem() {}
        Public inventorySize As Integer = 100
    End Class


End Class
