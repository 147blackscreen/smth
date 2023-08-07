using OwnObjects;

Console.WriteLine("-----------LIST--------------");
OwnObjects.List ownlist = new OwnObjects.List();
ownlist.Add(12);
ownlist.Add("1");
ownlist.Add("2");
ownlist.Add("3");
ownlist.Add("4");
ownlist.ShowItems();
ownlist.Add("5");
ownlist.Add("6");
ownlist.Add("7");
ownlist.Add("8");
ownlist.Add("9");
ownlist.Add("10");
ownlist.Add(12);
ownlist.ShowItems();
ownlist.Insert(0, "11");
ownlist.ShowItems();



ownlist.Remove(12);
ownlist.ShowItems();
ownlist.RemoveAt(11);
ownlist.ShowItems();
ownlist.Clear();
ownlist.Add("123");
ownlist.Add(12);
ownlist.Add("1");
ownlist.ShowItems();
Console.WriteLine(ownlist.Contains(12));
Console.WriteLine(ownlist.Contains("123"));
Console.WriteLine(ownlist.Contains("13"));
Console.WriteLine("Index of: " + ownlist.IndexOf(12));
var array = ownlist.ToArray();
foreach (var item in array)
{
    Console.WriteLine(item);
}

ownlist.Reverse();
ownlist.ShowItems();
ownlist[0] = "first";
Console.WriteLine(ownlist.Count);
ownlist.ShowItems();


Console.WriteLine("-----------SingleLIST--------------");



var singleList = new SingleList("abc");
singleList.Add(1);
singleList.Add(2);
singleList.Add(3);
singleList.Add(4);
singleList.Add(5);
Console.WriteLine(singleList.Last);
singleList.ShowItems();
singleList.AddFirst("first");
singleList.ShowItems();
Console.WriteLine(singleList.First);
singleList.Insert(0, "insert");
singleList.Insert(2, "insert");
singleList.ShowItems();


Console.WriteLine("-----------TwoLIST--------------");



var twolist = new TwoList();
twolist.Add("123");
twolist.Add("12");
twolist.Add(144);
twolist.ShowItems();
twolist.AddFirst("first");
twolist.ShowItems();
twolist.Add("add");
twolist.ShowItems();
twolist.AddFirst("first2");
twolist.ShowItems();
twolist.Remove("first");
twolist.ShowItems();
var list = twolist.ToArray();
Console.WriteLine(twolist.Contains("12"));
twolist.ShowItems();

Console.WriteLine();


Console.WriteLine("-----------Queue--------------");



var queue = new MyQueue(10);
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.ShowQueue();
queue.Enqueue(4);
queue.Enqueue(5);
queue.Dequeue();
queue.Dequeue();
queue.ShowQueue();
object[] arr = queue.ToArray();
foreach (object item in arr)
    Console.WriteLine(item);


Console.WriteLine("-----------Stack--------------");



var stack = new OwnStack(10);
stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.ShowStack();
stack.Pop();
stack.Pop();
stack.ShowStack();


Console.WriteLine("-----------TREE--------------");


OwnTree tree = new OwnTree();

// --- test rebalance --- //
//tree.Add(1);
//tree.Add(2);
//tree.Add(3);
//tree.Add(4);
//tree.Add(5);
//tree.Add(6);
//tree.Add(7);
//tree.Add(8);
//tree.Add(9);
//tree.Add(10);
//tree.Add(11);
//tree.Add(12);
//tree.Add(13);
//tree.Add(14);
//tree.Add(15);
//tree.Add(16);
//tree.Add(17);
//tree.Add(18);
//tree.Add(19);
//tree.Add(20);
//tree.Add(21);
//tree.Add(22);
//tree.Add(23);
//tree.Add(24);
//tree.Add(25);
//tree.Add(26);
//tree.Add(27);
//tree.Add(28);
//tree.Add(29);
//tree.Add(30);
//tree.Add(31);
//tree.Add(32);



tree.Add(27);
tree.Add(23);
tree.Add(35);
tree.Add(16);
tree.Add(25);
tree.Add(33);
tree.Add(41);
tree.Add(8);
tree.Add(20);
tree.Add(24);
tree.Add(26);
tree.Add(29);
tree.Add(34);
tree.Add(39);
tree.Add(44);
tree.Add(1);
tree.Add(13);
tree.Add(28);
tree.Add(31);
tree.Add(10);
tree.Add(15);
tree.Add(30);
tree.Add(32);
tree.Add(9);
tree.Add(11);
tree.Add(12);


tree.ReBalanceTree();


tree.ShowTree();

Console.WriteLine("---- FINISH ----");
var array1 = tree.ToArray();
foreach (var item in array)
    Console.WriteLine(item);

tree.Contains(1);
