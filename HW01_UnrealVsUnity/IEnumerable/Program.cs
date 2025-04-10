/*
IEnumerable 인터페이스
https://learn.microsoft.com/ko-kr/dotnet/api/system.collections.generic.ienumerable-1?view=net-9.0

IEnumerable: List, Array 등의 데이터에서 하나씩 꺼내 쓸 수 있게 해주는 인터페이스

동작 구조
GetEnumator()로 Enumerator 객체 생성 -> MoveNext()로 다음 데이터 확인 -> Current 현재 데이터 반환
*/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class App
{
    public static void Main()
    {
        TestStreamReaderEnumerable(); //반복기 방식
        Console.WriteLine("---");
        TestReadingFile(); //파일 전부 읽고 처리하는 방식
    }
    
    //반복기 방식
    public static void TestStreamReaderEnumerable()
    {
        long memoryBefore = GC.GetTotalMemory(true); //시작 전 메모리 확인

        IEnumerable<String> stringsFound;
 
        try 
        {
            stringsFound =
                from line in new StreamReaderEnumerable("./tempFile.txt") //파일 열기
                where line.Contains("string to search for") // 문자열 검색
                select line;
            
            Console.WriteLine("Found: " + stringsFound.Count());
        }
        catch (FileNotFoundException) { //예외처리
            Console.WriteLine(@"This example requires a file named ./tempFile.txt.");
            return;
        }
        
        // 반복기 사용 후 메모리 사용량 출력
        long memoryAfter = GC.GetTotalMemory(false);
        Console.WriteLine("Memory Used With Iterator = \t"
            + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
    }

/**********************************************************************************************/
    //파일 전부 읽고 처리하는 방식
    public static void TestReadingFile()
    {
        long memoryBefore = GC.GetTotalMemory(true);
        StreamReader sr;
        try {
            sr = File.OpenText("./tempFile.txt");
        }
        catch (FileNotFoundException) {
            Console.WriteLine(@"This example requires a file named ./tempFile.txt.");
            return;
        }

        //파일 내용을 리스트에 전부 넣음 
        List<string> fileContents = new List<string>();

        while (!sr.EndOfStream) {
            fileContents.Add(sr.ReadLine());
        } 

        //문자열 검색
        var stringsFound =
            from line in fileContents
            where line.Contains("string to search for")
            select line;

        sr.Close();

        Console.WriteLine("Found: " + stringsFound.Count());

        //반복기 사용 안했을 때(파일 그냥 읽었을 때)의 메모리 사용량
        long memoryAfter = GC.GetTotalMemory(false);
        Console.WriteLine("Memory Used Without Iterator = \t" +
            string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
    }
}

// IEnumerable<T> 구현 클래스
// IEnumerable<T> 구현시 IEnumerable 및 IEnumerator<T>둘다 구현 필요
public class StreamReaderEnumerable : IEnumerable<string>
{
    private string _filePath;
    public StreamReaderEnumerable(string filePath)
    {
        _filePath = filePath;
    }

    // IEnumerator 리턴(StreamReaderEnumerator)
    public IEnumerator<string> GetEnumerator()
    {
        return new StreamReaderEnumerator(_filePath);
    }

    //호출
    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }
}

// IEnumerator<T> 구현 클래스 (파일 내용 한줄씩 읽는 역할)
public class StreamReaderEnumerator : IEnumerator<string>
{
    private StreamReader _sr;
    public StreamReaderEnumerator(string filePath)
    {
        _sr = new StreamReader(filePath);
    }

    private string? _current; //현재 값 반환
    public string Current /
    {
        get
        {
            if (_sr == null || _current == null)
            {
                throw new InvalidOperationException();
            }

            return _current;
        }
    }

    private object Current1
    {

        get { return this.Current; }
    }

    object IEnumerator.Current
    {
        get { return Current1; }
    }

    public bool MoveNext() //다음줄 읽기
    {
        _current = _sr.ReadLine();
        if (_current == null)
            return false;
        return true; 
    }

    public void Reset() //StreamReader 상태 초기화
    {
        _sr.DiscardBufferedData();
        _sr.BaseStream.Seek(0, SeekOrigin.Begin);
        _current = null;
    }

    // IDisposable 구현 (자원 해제)
    private bool disposedValue = false;
    
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                // 관리 리소스 해제 부분
            }
            _current = null;
            if (_sr != null) {
               _sr.Close();
               _sr.Dispose();
            }
        }

        this.disposedValue = true;
    }

     ~StreamReaderEnumerator()
    {
        Dispose(disposing: false);
    }
}
