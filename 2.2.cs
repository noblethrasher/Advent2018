 static IEnumerable<char> FindEditDist2(string[] args)
  {
      Dictionary<string, string> memo = new Dictionary<string, string>();

      while (args.Length > 1)
      {
          var p = args[0];
          var arg_next = new List<string>();

          foreach (var s in args.Skip(1))
          {
              var diff = 0;

              for (var i = 0; i < s.Length; i++)
                  if (s[i] != p[i])
                      if (++diff > 1)
                          break;

              if (diff == 1)
                  memo.Add(p, s);
              else
                  arg_next.Add(s);
          }

          try
          {
              if (memo.TryGetValue(p, out var s))
              {
                  for (var i = 0; i < p.Length; i++)
                      if (s[i] == p[i])
                          yield return s[i];
               
                   break;
              }
          }
          finally
          {
              args = arg_next.ToArray();
          }
      }
  }
