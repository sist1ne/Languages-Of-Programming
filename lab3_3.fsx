open System

printfn "Добро пожаловать! \nЭта программа ищет количество файлов в катологе, начинающихся с заданного символа."

let rec PathInput () = 
    printfn "Введите путь к каталогу: "
    let path = Console.ReadLine()
    
    if IO.Directory.Exists path then 
        path 
    else 
        printfn "Указанный путь не существует!"
        PathInput ()

let rec CharInput () =  
    printfn "\nВведите начальный символ:"
    let succ, res = Char.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "Введите один символ!"
        CharInput ()

let rec FileCount path letter = 
    let files = Array.toSeq (IO.Directory.GetFiles(path))

    let fileNames = Seq.map (fun (elem:string) -> IO.Path.GetFileName(elem) ) files

    Seq.fold (fun acc (elem:string) ->
    if elem[0] = letter then 
        acc + 1
    else 
        acc
    ) 0 fileNames

let rec Main () = 
    printfn "Что вы хотите сделать?"
    printfn "1. Найти количество файлов, начинающихся с символа"
    printfn "----------------------------------------"
    printfn "2. Выйти из программы"
    printfn "\nВыберите действие: "

    let input = Console.ReadLine()
    printfn ""

    if input = "1" then
        let path = PathInput ()
        let char = CharInput ()

        let amount = FileCount path char 

        printfn "Число файлов, начинающихся с '%c': %d" char amount
        printfn "========================================"

        Main ()
    elif input = "2" then
        exit 0
    else 
        printfn "Пожалуйста, выберите действие! \n"
        Main ()

Main ()