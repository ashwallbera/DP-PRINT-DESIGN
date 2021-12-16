import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-productservice',
  templateUrl: './productservice.component.html',
  styleUrls: ['./productservice.component.scss'],
})
export class ProductserviceComponent implements OnInit {
  products = [{
    id:"1",
    name:"Wedding and Stationary",
    imgUri:"https://i.pinimg.com/564x/bb/f8/c2/bbf8c2e3efe5d8778d5d07315782a466.jpg",
    description:"We offer a selection of personalised birthday, wedding, christening invitations, suitable for both men and women, and for a wide range of party styles or themes."
  },{
    id:"1",
    name:"Marketing Material",
    imgUri:"https://i.pinimg.com/564x/73/29/b0/7329b0ad863ca65af6b69f892da57e8a.jpg",
    description:" Gear up for events and promotions with postcards, flyers, brochures, signage and beverages."
  },{
    id:"1",
    name:"Clothing",
    imgUri:"https://i.pinimg.com/564x/fa/da/eb/fadaebbafc8dd29b277f0d94cfc925d2.jpg",
    description:"Print to look Professional. Customise front chest, back chest and back"
  }
];
  constructor() {
  
  }

  ngOnInit(): void {}
}

class ProductServices {
  id: string = '';
  name: string = '';
  imgUri: string = '';
  description: string = '';
}
