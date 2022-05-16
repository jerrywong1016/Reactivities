let data: any = "23"; // turn data to non-type variable (disable type safety)
let data2: number | string = "23"; // turn data to non-type variable (disable type safety)

export interface Duck {
    name:any; //in the video it's string, but throw error when I try to use it as the 
    numLegs: number;
    makeSound?:(sound:string) => void //puting ? make the property optional
}

const duck1:Duck = {
    name: 'huey',
    numLegs:2,
    makeSound: (sound: any) => console.log(sound)
}

const duck2 : Duck= {
    name: 'dewey',
    numLegs:2,
    makeSound: (sound: any) => console.log(sound)
}

// duck1.name = "1";
duck1.makeSound!("t"); //Cannot invoke an object which is possibly 'undefined'.ts
//if the object extends the interface, you need to make sure the type follow the type specified in interface

export const ducks = [duck1,duck2];
