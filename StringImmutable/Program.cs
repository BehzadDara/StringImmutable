#region used
using System.Diagnostics;
using System.Text;
#endregion

#region description
// string is reference type. it means that it has an address which is stored in stack
// and the address is point to its value which is stored in heap
// stack is managed automatically and heap should be managed by developer.
// in c# the garbage collector (GC) manages the heap.

// note that string is immutable because it's an array of chars and an array has variable length.
// a refrence type points to fixed number of blocks in heap and when ever it needs to be changed,
// another address of heap is assigned to it.

// strings are thread safe because it is an immutable type.
// ( string is immutable to be thread safe [ reason of string being immutable ] )
// An object is not thread safe if the value/state of that object can change while a thread is reading it.
// This generally happens if a second thread changes this object's value while the first thread is reading it.
// An immutable object, by definition, cannot change value/state.
// Since every time you read an immutable object it has the same value/state,
// you can have any number of threads read that object with no concerns.
// so string is thread safe because when a thread changes its value, the address changes
// but when another thread is reading it " at the same time", it reads the old value without change.
#endregion

#region section 1
var x = "s1";
var y = x;
x = "s2";
Console.WriteLine($"x:{x}, y:{y}");
// x point to s1, then y point to s1, then x changes its point to s2
// ( string is immutable so the value can not change.
// Therefore x needs to point to another address for new value ) 
#endregion

#region section 2
var a = "s3";
myFunction(a);
Console.WriteLine($"a:{a}");
// a is s3, because string is immutable and changed one in method is another string
static void myFunction(string a)
{
    a = "s4";
}
#endregion

#region section 3
var p = "s5";
var q = "s5";
// after compile, both of p and q point to one block of heap which has the value s5.
// this is called " string intern "
#endregion

#region section 4
var timer1 = new Stopwatch();
var z = "";
timer1.Start();
for (int i = 0; i < 100000; i++)
{
    z += i.ToString();
}
timer1.Stop();
Console.WriteLine(timer1.ElapsedMilliseconds);
// it change the address of z, 1000 time. time of execution is 10600 ms

var timer2 = new Stopwatch();
var sb = new StringBuilder("");
timer2.Start();
for (int i = 0; i < 100000; i++)
{
    sb.Append(i.ToString());
}
timer2.Stop();
Console.WriteLine(timer2.ElapsedMilliseconds);
// it append address of new string at the end of previous string and changes it length.
// time of execution is 3 ms
#endregion

