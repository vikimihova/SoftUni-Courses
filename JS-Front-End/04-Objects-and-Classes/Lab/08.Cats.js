function solve(inputData) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = Number(age);
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (let line of inputData) {
        let [name, age] = line.split(' ');

        let currentCat = new Cat(name, age);
        currentCat.meow();
    }
}

solve(['Mellow 2', 'Tom 5']);