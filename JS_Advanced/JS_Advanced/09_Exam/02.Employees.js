function solveClasses() {
    class Developer {
        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.tasks = [];
            this.experience = 0;
        }

        addTask(id, taskName, priority) {
            let taskObject = {id, taskName, priority};
            
            if (priority === 'high') {
                this.tasks.unshift(taskObject);
            } else {
                this.tasks.push(taskObject);
            }
            
            return `Task id ${id}, with ${priority} priority, has been added.`;
        }

        doTask() {
            if (this.tasks.length === 0) {
                return `${this.firstName}, you have finished all your tasks. You can rest now.`
            } else {
                let task = this.tasks.shift();

                return task.taskName;
            }
        }

        getSalary() {
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`;
        }

        reviewTasks() {
            let result = ["Tasks, that need to be completed:"];

            while (this.tasks.length > 0) {
                let currentTask = this.tasks.shift();

                result.push(`${currentTask.id}: ${currentTask.taskName} - ${currentTask.priority}`)
            }
 
            return result.join('\n')
        }
    }

    class Junior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);

            this.baseSalary += bonus;
            this.experience = experience;
        }

        learn(years) {
            this.experience += Number(years);
        }
    }

    class Senior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);

            this.baseSalary += bonus;
            this.experience = Number(experience) + 5;
        }

        changeTaskPriority(taskId) {
            let task = this.tasks.find(x => x.id === taskId);
            let index = this.tasks.indexOf(task);
            
            this.tasks = this.tasks.splice(index, 1);
    
            if (task.priority === 'high') {
                task.priority = 'low';
                this.tasks.push(task);
            } else {
                task.priority = 'high';
                this.tasks.unshift(task);
            }
    
            return task;
        }
    }

    return {
        Developer,
        Junior,
        Senior
    }
}

//Input Example
let classes = solveClasses();
const developer = new classes.Developer("George", "Joestar");
console.log(developer.addTask(1, "Inspect bug", "low"));
console.log(developer.addTask(2, "Update repository", "high"));
console.log(developer.reviewTasks());
console.log(developer.getSalary());
const junior = new classes.Junior("Jonathan", "Joestar", 200, 2);
console.log(junior.getSalary());
const senior = new classes.Senior("Joseph", "Joestar", 200, 2);
senior.addTask(1, "Create functionality", "low");
senior.addTask(2, "Update functionality", "high");
console.log(senior.changeTaskPriority(1)["priority"]);
