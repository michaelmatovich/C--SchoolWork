
class Node {
    constructor(value, next = null) {
        this.data = value;
        this.next = next;
    }
}

class SLL {
    constructor() {
        this.head = null;
        this.size = 0;
    }

    isEmpty() {
        if(this.head == null) {
            return true;
        } else {
            return false;
        }

    }

    print() {
        var arr = [];
        var runner = this.head;
        while(runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        console.log(arr);
    }

    insertAtBack(val) {
        if(this.isEmpty()){
            this.head = new Node(val);
        } else {
            var runner = this.head;
            while(runner.next) {
                runner = runner.next;
            }
            runner.next = new Node(val);
        }
        this.size++;
    }
    
    insertAtFront(val) {
        this.head = new Node(val, this.head);
        this.size++;
    }
    
    removeHead(){
        let current = this.head;
        this.head = current.next;
        this.size--;
        return current;
    }
    
    average(){
        var runner = this.head;
        var sum = 0;
        while(runner) {
            sum += runner.data;
            runner = runner.next;
        }
        return (sum / this.size);
    }

    contains(val){
        let runner = this.head;
        while(runner){
            if(runner.data === val){
                return true;
            }
            runner = runner.next;
        }
        return false;
    }

    containsRecursive(value, runner = this.head){
        if(runner.data == value){
            return true;
        }
        if(!runner.next){
            return false;
        }
        return this.containsRecursive(value, runner.next);
    }

    removeBack(){
        let runner = this.head;
        if(this.isEmpty()){
            return "There are no nodes in this list.";
        }
        if(runner.next){
            let temp = new Node(this.head.data);
            this.removeHead();
            return temp;
        }
        while(runner.next.next){
            runner = runner.next;
        }
        let temp = new Node(runner.next.data);
        runner.next = null;
        return temp;
    }
    secondToLast() {
        let runner = this.head;
        if(this.isEmpty()){
            return false;
        }
        if(!runner.next){
            return false;
        }

        while (runner.next.next) {
            runner = runner.next;
        }
        return runner;
    }
    removeVal(val) {
        if(this.isEmpty()){
            return false;
        }
        let runner = this.head;
        
        while(runner.next) {
            if(runner.data == val){
                doesContain = true;
                break;
            }
            runner = runner.next;
        }

        if(!runner.next){
            if(runner.data === val){
                this.removeBack();
                return true;
            }
            else{
                return false;
            }
        }
        let temp = runner.next;
        runner.next = temp.next;
        temp.next = null;
        return true;
    }

    prepend(ValA, ValB) {
        let runner = this.head;
        while(runner.next){
            if(runner.next.data == ValB){
                break;
            }
            runner = runner.next;
        }
        if(!runner.next){
            return false;
        }
        let temp = runner.next;
        runner.next = new Node(ValA, temp);
        return true;
    }
}


let sll = new SLL();
sll.insertAtFront(4);
sll.insertAtBack(5);
sll.insertAtBack(6);
sll.print();

console.log(sll.secondToLast()); 

sll.print();