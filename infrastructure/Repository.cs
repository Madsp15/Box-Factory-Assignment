using System.Collections.Generic;
using Dapper;

namespace infrastructure;

public class Repository
{
    public Box AddBox(Box box)
    {
        var sql = $@"INSERT INTO tables.boxes(width, length, height, volume, material, inventory_count, price, name)
                        VALUES(@width, @length, @height, @volume, @material, @inventorycount, @price, @name)
                        RETURNING
                        id as {nameof(Box.Id)},
                        width as {nameof(Box.Width)},
                        length as {nameof(Box.Length)},
                        height as {nameof(Box.Height)},
                        volume as {nameof(Box.Volume)},
                        material as {nameof(Box.Material)},
                        inventory_count as {nameof(Box.InventoryCount)},
                        price as {nameof(Box.Price)},
                        name as {nameof(Box.Name)};";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new
            {
                width = box.Width, length = box.Length, height = box.Height, volume = box.Volume,
                material = box.Material, inventorycount = box.InventoryCount, price = box.Price, name = box.Name
            });
        }
    }

    public Box GetBoxById(int boxId)
    {
        var sql = $@"SELECT *, inventory_count as inventorycount FROM tables.boxes WHERE id = @id;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new { id=boxId });
        }
    }

    public bool DeleteBoxById(int boxId)
    {
        var sql = $@"DELETE FROM tables.boxes WHERE id = @id;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new
            {
                id = boxId
            }) == 1;
        }
    }

    public IEnumerable<Box> GetAllBoxes()
    {
        var sql = $@"SELECT *, inventory_count as InventoryCount FROM tables.boxes;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.Query<Box>(sql);
        }
    }

    public Box UpdateBox(Box box)
    {
        var sql = $@"UPDATE tables.boxes
                        SET width=@width, length=@length, height=@height, volume=@volume,
                            material=@material, inventory_count=@inventorycount, price=@price, name=@name 
                        WHERE id=@id
                        RETURNING
                        id as {nameof(Box.Id)},
                        width as {nameof(Box.Width)},
                        length as {nameof(Box.Length)},
                        height as {nameof(Box.Height)},
                        volume as {nameof(Box.Volume)},
                        material as {nameof(Box.Material)},
                        inventory_count as {nameof(Box.InventoryCount)},
                        price as {nameof(Box.Price)},
                        name as {nameof(Box.Name)};";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new
            {
                width = box.Width, length = box.Length, height = box.Height, volume = box.Volume,
                material = box.Material, inventorycount = box.InventoryCount, price = box.Price, id = box.Id, name= box.Name
            });
        }
    }

    public IEnumerable<Box> SearchForBoxByName(string query)
    {
        var sql = @"SELECT * FROM tables.boxes 
                WHERE LOWER(name) LIKE '%' || @query || '%'
                ORDER BY id;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.Query<Box>(sql, new { query = "%" + query.ToLower() + "%" });
        }
    }
}