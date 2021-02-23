module BinPack.Test.Utils
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

open BinPack

let generateInputs (commands: (int * int * int) list) = 
    List.collect (fun (w, h, count) ->
        List.init count (fun _ -> { W = w; H = h; Tag = () })) commands

let fillRate result =
    let allArea = result.Width * result.Height
    let rectArea = result.Rects |> List.sumBy (fun (x, _) -> x.W * x.H)
    float rectArea / float allArea

let test testName commands =
    let result = generateInputs commands |> binPack
    let fillRate = fillRate result
    printfn "Width=%d, Height=%d, FillRate = %2.2f%%" result.Width result.Height (fillRate * 100.0)
    printfn "== Rects =="
    result.Rects
    |> List.iter (printfn "%A")

    let random = System.Random ()

    use font = new System.Drawing.Font ("Fira Code", 64.0f)

    use bitmap = new System.Drawing.Bitmap (result.Width, result.Height)
    use g = System.Drawing.Graphics.FromImage bitmap
    for (rect, ()) in result.Rects do
        let col = System.Drawing.Color.FromArgb(
                    random.Next() % 256,
                    random.Next() % 256,
                    random.Next() % 256)
        use brush = new System.Drawing.SolidBrush (col)
        let rect = System.Drawing.Rectangle.FromLTRB (rect.X, rect.Y, rect.X + rect.W, rect.Y + rect.H)
        g.FillRectangle (brush, rect)
    (*let fillRateStr = sprintf "%2.2f%%" <| fillRate * 100.0
    use brush = System.Drawing.Brushes.Black
    g.DrawString (fillRateStr, font, brush, System.Drawing.PointF(0.0f, 0.0f))*)
    bitmap.Save (testName + ".png")


