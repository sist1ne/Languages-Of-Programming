open System

printfn "����� ����������! \n��� ��������� ���� ���������� ������ � ��������, ������������ � ��������� �������."

let rec PathInput () = 
    printfn "������� ���� � ��������: "
    let path = Console.ReadLine()
    
    if IO.Directory.Exists path then 
        path 
    else 
        printfn "��������� ���� �� ����������!"
        PathInput ()

let rec CharInput () =  
    printfn "\n������� ��������� ������:"
    let succ, res = Char.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "������� ���� ������!"
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
    printfn "��� �� ������ �������?"
    printfn "1. ����� ���������� ������, ������������ � �������"
    printfn "----------------------------------------"
    printfn "2. ����� �� ���������"
    printfn "\n�������� ��������: "

    let input = Console.ReadLine()
    printfn ""

    if input = "1" then
        let path = PathInput ()
        let char = CharInput ()

        let amount = FileCount path char 

        printfn "����� ������, ������������ � '%c': %d" char amount
        printfn "========================================"

        Main ()
    elif input = "2" then
        exit 0
    else 
        printfn "����������, �������� ��������! \n"
        Main ()

Main ()