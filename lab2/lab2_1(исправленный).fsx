open System

printfn "����� ����������! \n��� ��������� ��������� � ������ ������� �������� ������ �������� ������."

let rec AddInput () =  
    printfn "\n������� ������, ������� ������ �������� � ������ ������� ��������: "
    let succ, res = Char.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "������� ���� ������!"
        AddInput ()

let rec GetN () = 
    printf "������� ���������� ��������� ��� ������: "
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

let Print (spisok) = 
    printf "%A" spisok

let HandFill (n) =
    [
        for i in 1..n do 
            printf "������� %d ������� ������: " i
            yield Console.ReadLine()
    ]

let alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTYVWXYZ�������������������������������������Ũ��������������������������0123456789" 
let alp_size = 128

let GenerateWord (size) =
    [                        //������ �� ����
        for i in 1..size do                    //���� ��� ���������� ������ �� �������� 
            let temp = Random().Next(0, alp_size-1) 
            yield alphabet[temp]
    ]

let GenerateSentence (size) = 
    [                            
        for i in 1..size do                        
            let word_size = Random().Next(1, 6)
            yield String.Concat(GenerateWord (word_size))
    ]

let RandFill (n) =
    [
        for i in 1..n do
            let sent_size = Random().Next(1, 6)

            let sentence = GenerateSentence (sent_size)
            yield String.Join(" ", sentence)
    ]

let AddFront (theList:string list) (symbol:char) = 
    let add = string(symbol)
    List.map (fun elem -> add + elem) theList

let rec Main () = 
    printfn "\n��� ��������� ������?"
    printfn "1. ������ �����������"
    printfn "2. ��������� �����������"
    printfn "----------------------------------------"
    printfn "3. ����� �� ���������"
    printfn "\n�������� ��������: "

    let input = Console.ReadLine()

    if input = "1" then 
        let num = GetN ()
        let spisok = HandFill (num)
        printf "\n�������������� ������: "
        Print (spisok)

        let spisok1 = AddFront spisok (AddInput ())

        printf "\n��������� ����������: "
        Print (spisok1) 
        printf "\n========================================"

        Main ()
    elif input = "2" then 
        let num = GetN ()
        let spisok = RandFill (num)
        printf "\n�������������� ������: "
        Print (spisok)

        let spisok1 = AddFront spisok (AddInput ())

        printf "\n��������� ����������: "
        Print (spisok1) 
        printf "\n========================================"

        Main ()
    elif input = "3" then 
        exit 0
    else 
        printfn "����������, �������� ��������! \n"
        Main ()

Main ()