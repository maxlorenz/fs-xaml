module MainWindow

open System.Windows.Controls

open UI

let configure window =
    
    let btnClick    :Button     = window?btnClick
    let txtInput    :TextBox    = window?txtInput

    btnClick.Click.Add(fun _ -> txtInput.Text <- sprintf "Clicked at %A" System.DateTime.Now)

let run() =
    
    "MainWindow.fs.xaml"
    |> UI.load
    |> UI.configure configure
    |> UI.run