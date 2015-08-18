module UI

open System
open System.Reflection
open System.Windows
open System.Windows.Controls

let (?) (c:obj) (s:string) =
    match c with
    | :? ResourceDictionary as r -> r.[s] :?> 'T
    | :? Control as c -> c.FindName(s) :?> 'T
    | _ -> failwith "dynamic lookup failed"

let load name =
    let applicationName = Assembly.GetExecutingAssembly().FullName
    let resource = Uri(sprintf "/%s;component/%s" applicationName name, System.UriKind.Relative)

    Application.LoadComponent(resource) :?> Window

let configure (configure: Window -> unit) window =
    configure window; window

let run window =
    do (Application()).Run(window) |> ignore

let show (window: Window) =
    window.Show()