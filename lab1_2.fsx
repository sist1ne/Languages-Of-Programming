open System

printfn "����� ����������, ������������! ��� ��������� ������ ��������� ����� � ������"

let rec start () = 
    printfn "1. ������ ���� �����"
    printfn "2. ����� �� ���������"
    printfn "�������� ��������: "

    let h = Console.ReadLine()

    try
        int h
    with
    | ex ->
        printfn "����������, �������� ��������."
        printfn ""

        start ()

let rec str () =
    printf "������� �����: "

    Console.ReadLine()

let isNum stroka =
    try 
        let useless = float(stroka)
        true
    with 
        | ex -> false

let rec listMaker stroka = 
    if stroka = "" then 
        []
    else
        match stroka[0] with 
        | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> (int(stroka[0]) - 48) :: listMaker(stroka[1..])
        | _ -> listMaker(stroka[1..])

let show a = 
    printfn "�������������� ������: %A" a 

let rec cycleWork () = 
    let help = start () 

    if help = 1 then 
        let temp = str()
        if isNum(temp) then 
            let spisok = listMaker (temp)
            printfn ""

            show spisok
            printfn ""

            cycleWork ()
        else
            printfn "��������� ������ �� �����!"
            printfn ""

            cycleWork ()
    elif help = 2 then
        printfn "���������� ������..."
        printfn ""

        exit 0
    else
        printfn "����������, �������� ��������."
        printfn ""

        cycleWork ()

let main = 
    cycleWork ()