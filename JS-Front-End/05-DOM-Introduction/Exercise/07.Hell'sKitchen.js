function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      //Input/Output elements
      const input = document.querySelector('#inputs textarea').value;
      const outputElementBestRestaurant = document.querySelector('#bestRestaurant p');
      const outputElementWorkers = document.querySelector('#workers p');

      //Regex matches for separate input entries
      const restaurantDataPattern = /[A-Za-z0-9 ,-]+\d/g;
      const restaurantMatches = input.match(restaurantDataPattern);

      //Restaurant class
      class Restaurant {
         constructor(name){
            this.name = name;            
            this.workers = [];
            this.bestSalary = 0;
            this.averageSalary = 0;            
         }

         calcAverageSalary() {
            let totalSalaryAmount = 0;
            this.workers.forEach(x => totalSalaryAmount += x.salary);
            this.averageSalary = totalSalaryAmount / this.workers.length;
         } 
      }

      //Restaurant objects with data
      const restaurants = [];

      for (let match of restaurantMatches) {
         //Getting data per restaurant
         const [restaurantName, workers] = match.split(' - ');
         const workersArray = workers.split(', ');

         //Adding restaurant to array and selecting it    
         if (!restaurants.includes(x => x.name == restaurantName)){
            restaurants.push(new Restaurant(restaurantName));
         }  

         let currentRestaurant = restaurants.find(x => x.name == restaurantName);       

         //Adding workers as objects to a restaurant object, setting best salary for restaurant
         for (let worker of workersArray) {
            let [workerName, workerSalary] = worker.split(' ');

            currentRestaurant.workers.push({ name: workerName, salary: Number(workerSalary) });

            if (workerSalary > currentRestaurant.bestSalary) {
               currentRestaurant.bestSalary = Number(workerSalary);
            }
         }
      }

      //Calculating average salary and finding best restaurant
      restaurants.forEach(x => x.calcAverageSalary());

      let sortedRestaurants = restaurants.sort((a, b) => b.averageSalary - a.averageSalary);
      let bestRestaurant = sortedRestaurants[0];

      let sortedWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      //Output
      outputElementBestRestaurant.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

      sortedWorkers.forEach(x => outputElementWorkers.textContent += `Name: ${x.name} With Salary: ${x.salary} `);
   }
}