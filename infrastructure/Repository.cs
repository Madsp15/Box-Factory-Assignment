﻿using System.Collections.Generic;
using Dapper;

namespace infrastructure;

public class Repository
{
    public Box AddBox(Box box)
    {
        var sql = $@"INSERT INTO boxes(width, length, height, volume, material, inventory_count, price)
                        VALUES(@width, @length, @height, @volume, @material, @inventorycount, @price)
                        RETURNING
                        id as {nameof(Box.Id)},
                        width as {nameof(Box.Width)},
                        length as {nameof(Box.Length)},
                        height as {nameof(Box.Height)},
                        volume as {nameof(Box.Volume)},
                        material as {nameof(Box.Material)},
                        inventory_count as {nameof(Box.InventoryCount)},
                        price as {nameof(Box.Price)};";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new
            {
                width = box.Width, length = box.Length, height = box.Height, volume = box.Volume,
                material = box.Material, inventorycount = box.InventoryCount, price = box.Price
            });
        }
    }

    public Box GetBoxById(int boxId)
    {
        var sql = $@"SELECT * FROM boxes WHERE id = @id;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new { id=boxId });
        }
    }

    public bool DeleteBoxById(int boxId)
    {
        var sql = $@"DELETE FROM boxes WHERE id = @id;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new { boxId }) == 1;
        }
    }
    
    public IEnumerable<Box> GetAllBoxes()
    {
        var sql = $@"SELECT * FROM boxes;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.Query<Box>(sql);
        }
    }

    public Box UpdateBox(Box box)
    {
        var sql = $@"UPDATE boxes
                        SET width=@width, length=@length, height=@height, volume=@volume,
                            material=@material, inventory_count=@inventorycount, price=@price 
                        WHERE id=@id
                        RETURNING
                        id as {nameof(Box.Id)},
                        width as {nameof(Box.Width)},
                        length as {nameof(Box.Length)},
                        height as {nameof(Box.Height)},
                        volume as {nameof(Box.Volume)},
                        material as {nameof(Box.Material)},
                        inventory_count as {nameof(Box.InventoryCount)},
                        price as {nameof(Box.Price)};";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new
            {
                width = box.Width, length = box.Length, height = box.Height, volume = box.Volume,
                material = box.Material, inventorycount = box.InventoryCount, price = box.Price, id = box.Id
            });
        }
    }

    public IEnumerable<Box> SearchForBox(string query)
    {
        var sql = $@"SELECT * FROM boxes 
                        WHERE LOWER(material) LIKE '%' || @query || '%'
                        ORDER BY id;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.Query<Box>(sql, new { query });
        }
    }
}