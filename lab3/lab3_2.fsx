open System

printfn "����� ����������! \n��� ��������� ���� ���������� ��������� � �������� ������������� �������."

let rec LenInput () =  
    printfn "\n������� ��������� ���������� �������� � �������� ������: "
    let succ, res = Int32.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "������� �����!"
        LenInput ()

let rec GetN () = 
    printf "������� ���������� ��������� ��� ������������������: "
    let succ, res = Int32.TryParse(Console.ReadLine())

    if succ = true then 
        if (res >= 0) then 
            res
        else 
            printfn "���������� ��������� �� ����� ���� �������������! \n"
            GetN ()
    else 
        printfn "����������, ������� �����! \n"
        GetN ()

let PrintOut (sequence) =
    Seq.iter (fun elem -> printf "'%s'; " elem) sequence
    printfn ""

let HandFill (size) =
    [
        for i in 1..size do 
            printf "������� %d ������� ������������������: " i
            yield Console.ReadLine()
    ]

let alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTYVWXYZ�������������������������������������Ũ��������������������������0123456789" 
let alp_size = 128

let GenerateWord (size) =
    [
        for i in 1..size do
            let temp = Random().Next(0, alp_size-1) 
            yield alphabet[temp]
    ]

let GenerateSentence (size) =
    [                            
        for i in 1..size do                        
            let word_size = Random().Next(1, 6)
            yield String.Concat(GenerateWord (word_size))
    ]

let RandFill (size) =
    [
        for i in 1..size do
            let sent_size = Random().Next(1, 6)
            let sentence = GenerateSentence (sent_size)
            yield String.Join(" ", sentence)
    ]

let rec InputPath () = 
    printfn "������� ���� � �����: "
    let path = Console.ReadLine()
    
    if IO.File.Exists path then 
        path 
    else 
        printfn "���������� ����� �� ����������!"
        InputPath ()

let rec FileFill (path:string) = 
    use file = new System.IO.StreamReader(path)

    [
        while not file.EndOfStream do
            file.ReadLine()
    ]

let LenSearch sequence lenght =
    Seq.fold 
        (fun acc stroka -> 
            if String.length stroka = lenght then 
                acc + 1 
            else acc
        ) 
        0 sequence

let rec Main () = 
    printfn "��� ��������� ������������������?"
    printfn "1. ������ �����������"
    printfn "2. ��������� �����������"
    printfn "3. ��������� �� �����"
    printfn "----------------------------------------"
    printfn "4. ����� �� ���������"
    printfn "\n�������� ��������: "

    let input = Console.ReadLine()
    printfn ""

    if input = "1" then 
        let num = GetN ()
        let posled = List.toSeq (HandFill (num))

        printfn "�������������� ������������������: "
        PrintOut (posled)

        let amount = LenSearch posled (LenInput())
        printfn "���������� ����� � �������� ����������� ��������: %d" amount
        printfn "========================================"

        Main ()
    elif input = "2" then
        let num = GetN ()
        let posled = List.toSeq (RandFill (num))

        printfn "�������������� ������������������: "
        PrintOut (posled)

        let amount = LenSearch posled (LenInput())
        printfn "���������� ����� � �������� ����������� ��������: %d" amount
        printfn "========================================"

        Main ()
    elif input = "3" then 
        let path = InputPath ()

        let posled = List.toSeq (FileFill(path))

        printfn "�������������� ������������������: "
        PrintOut (posled) 

        let amount = LenSearch posled (LenInput())
        printfn "���������� ����� � �������� ����������� ��������: %d" amount
        printfn "========================================"

        Main ()
    elif input = "4" then 
        exit 0
    else 
        printfn "����������, �������� ��������! \n"
        Main ()

Main ()