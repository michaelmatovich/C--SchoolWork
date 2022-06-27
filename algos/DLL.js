// Insert at Front
    // Insert a given value to the front of the doubly linked list
    InsertAtFront(val) {
        if(this.isEmpty()) {
            const newNode = new Node(val);
            this.head = newNode;
            this.tail = newNode;
            this.length++;
            return this;
        }

        const newNode = new Node(val);
        const prevHead = this.head;
        prevHead.previous = newNode;
        this.head = newNode;
        this.head.next = prevHead;
        this.length++;

        return this;
    }
