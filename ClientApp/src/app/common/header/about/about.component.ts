import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  language = 'html';
  content = '<p>test</p>';
  
  constructor() { }

  ngOnInit() {
  }

}
