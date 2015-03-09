#I @"./Packages/FsCheck.1.0.4/lib/net45"

#r "FsCheck.dll"

open FsCheck

let inline ( === ) (a:double) (b:double) =
  if System.Double.IsNaN(a) then System.Double.IsNaN(b)
  else a = b

type DoublePlusProperties private () =
  static member ``a + b = b + a`` (a:double) (b:double) =
    (a + b) === (b + a)

  static member ``(a + b) + c = a + (b + c)`` (a:double) (b:double) (c:double) =
    ((a + b) + c) === (a + (b + c))


let config = {
    Config.Quick with
        MaxTest = 1000
    }


Check.All(config, typeof<DoublePlusProperties>)
