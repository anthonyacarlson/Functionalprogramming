module Labs.Module3.DiscriminatedUnionsAnswers

open FsUnit.Xunit
open Xunit

type Grade =
    | APlus 
    | A
    | AMinus
    | F
    
let grade score =
    match score with
    | 100 -> APlus
    | s when s >= 93 && s <= 99 -> A
    | s when s >= 90 && s <= 92 -> AMinus
    | _ -> F

