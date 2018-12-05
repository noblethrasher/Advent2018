
let dup_freq ns =
    
    match List.length ns with
    | 0 -> 0
    | _ ->
    
        let memo = Dictionary<int, int>() //memo to record the number of times (the dictionary value) that a particular integer was seen (the dictionary key)
        memo.Add (0, 1)

        let rec f xs' freq =
            match xs' with
            | [] -> f ns freq //we didnt't find a duplicate on this iteration, so reiterate the list with the latest computed freq
            | x::xs ->
                let freq' = x + freq //compute new freq and call it freq' (read as "freq prime")
            
                let k' =
            
					//if the freq is not seen before, add it to the dictionary and return 1
                    match memo.TryGetValue freq' with
                    | (false, _) ->
                        memo.Add (freq', 1)
                        1
                    
					//if the freq was seen before, increment the number of times that it was seen by 1 and return that sum
                    | (true, k) -> 
                        let k' = k + 1
                        memo.[freq'] <- k'
                        k'
                
				//if the number of times that the freq was seen is 2 then we're done, else try again with the remainder of the list and new freq
                if k' > 1 then freq' else f xs freq' 
        f ns 0 //start with a frequency value of 0
