using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace poker3
{

  public class Program
  {
    static void Main()
    {
      var result = ReaderHelper.ReadFromFile(@"C:\Games\hand121.txt");
      var reader = new Reader("PoekrStars 21032103 ", 0);
      var pokerstars = reader.ReadRoomName();
      var number = reader.ReadGameNumber();
    }

  }

  static class ReaderHelper
  {
    //static string buffer = "";

    public static string ReadFromFile(string filePath)
    {
      string pokerText;
      using (FileStream pokerHand = File.OpenRead(filePath))
      {
        byte[] array = new byte[pokerHand.Length];
        pokerHand.Read(array, 0, array.Length);
        pokerText = System.Text.Encoding.Default.GetString(array);

      }
      return pokerText;

    }

    public static bool IsChar(this char args, char another)
    {
      if (args == another)
      {
        return true;
      }
      return false;
    }

    public static bool IsNumber(this char args)
    {//5
      if (args >= '0' && args <= '9')
        return true;
      return false;
    }
  }

  public class Reader
  {
    public string Buffer { get; set; }
    public int Cursor { get; set; }
    public Reader(string buffer, int cursor)
    {
      Buffer = buffer;
      Cursor = cursor;

    }

    public char ReadOne()
    {
      var current = Buffer[Cursor];
      Cursor++;
      return current;
    }

    public char GetCurrent()
    {
      return Buffer[Cursor];
    }

    public bool IsCurrentChar(char args)
    {
      var current = GetCurrent();
      return current.IsChar(args);
    }

    public void MoveNext()
    {
      Cursor++;
    }

    public void Skip(int count)
    { // move cursor on count
      var current = GetCurrent();
      do
      {
        MoveNext();
      }

      while (current != count);

    }

    public void SkipUntil(char args)
    { // move cursor until current == args
      var current = GetCurrent();
      do
      {
        MoveNext();
      }

      while (current != args);
    }

    public string ReadUntil(char args)
    { // read all chars until current == args  ????
      var current = GetCurrent();
      var result;
      if (current != args)
        result += current;

      return result;

    }

    public void SkipSpaces()
    { // skip while current == ' '
      var current = GetCurrent();
      do
      {
        MoveNext();
      } while (current == ' ');
    }

    public bool IsCurrentNumber()
    { // check if current is 0-9
      var current = GetCurrent();
      if (current >= '0' && current <= '9')
        return true;
      return false;
    }

    public long ReadInt()
    { // 213213gjigkhb read all numbers until current is not int
      var result;
      var current = GetCurrent();
      if (IsCurrentNumber())
        result += current;


      return result;
    }

    public bool TryReadInt(out long result)
    { // check if current is number and read all numbers until current is not int,
      // if first element is not number - return false
      result = ReadInt();
      return false;
    }

    public long ReadFirstInt()
    {// in buffer "sadasd102", and current == 's', method must return 102
      return 0;
    }

    public string ReadRoomName()
    { // Read PokerStars

      return "";
    }
    public string ReadGameType()
    {  // Hold'em No Limit
      return "";
    }


    public long ReadGameNumber()
    { // Read 196556868904
      return 0;
    }

    public string ReadStakes()
    { // $0.10/$0.25 USD
      return "";
    }
  }



}

