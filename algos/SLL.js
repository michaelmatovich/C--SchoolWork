//Node & SLL Classes

// Node class

class Node {
    constructor(value) {
        this.data = value;
        this.next = null;
    }
}

//Singly Linked List class

class SLL{
    constructor() {
        this.head = null;
    }

    //identify a sll is empty
    isEmpty() {
        return this.head == null;
    }

    print() {
        //push values into an array and print the array out
        var arr = [];
        var runner = this.head;
        //Use .push to push in the dataof the node    
        while(runner){
            arr.push(runner.data);
            runner = runner.next;
        }        
        console.log(arr);
    }

    insertAtBack(val){
        if(this.isEmpty()){
            this.head = new Node(val);
        }
        else
        {        
        var runner = this.head;

        while(runner.next){
            runner=runner.next;
        }

        runner.next = new Node(val);
        }
    }
}

var sll = new SLL();

var node1 = new Node(5);
var node2 = new Node(7);
var node3 = new Node(9);
var node4 = new Node(1);
var node5 = new Node(10);

sll.head = node1;

sll.head.next = node2;

sll.head.next.next = node3;

sll.head.next.next.next = node4;

sll.insertAtBack(10);


sll.print();