open System
open System.IO
open System.Collections.Generic

let dup_freq ns =
    
    match List.length ns with
    | 0 -> 0
    | _ ->
    
        let memo = Dictionary<int, int>()
        memo.Add (0, 1)
    
        let rec f xs' acc =
            match xs' with
            | [] -> f ns acc
            | x::xs ->
                let acc' = x + acc
            
                let k' =
            
                    match memo.TryGetValue acc' with
                    | (false, _) ->
                        memo.Add (acc', 1)
                        1
                    
                    | (true, k) ->
                        let k' = k + 1
                        memo.[acc'] <- k'
                        k'
                    
                if k' > 1 then acc' else f xs acc'
        f ns 0

let xs =
    use file = System.IO.File.Open(@"c:\users\rodrick\desktop\input1.2.txt", System.IO.FileMode.Open)
    use sr = new StreamReader(file)
    sr.ReadToEnd().Split([| Environment.NewLine |], StringSplitOptions.RemoveEmptyEntries) |> Array.toList |> List.map(fun x -> Int32.Parse(x))

    

let result = dup_freq xs
   
    
Console.WriteLine(result)
Console.ReadLine() |> ignore
