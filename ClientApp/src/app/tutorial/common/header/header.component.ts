import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  language = 'html';
  content = '<p>test</p>';

  constructor() { }

  ngOnInit() {
  }

}
