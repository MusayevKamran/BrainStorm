import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-html',
  templateUrl: './html.component.html',
  styleUrls: [
    './html.component.scss',
    '../tutorial.component.scss'
  ]
})
export class HtmlComponent implements OnInit {
  constructor() { }

  htmlUrlName = [
    { url: 'html-home', name: 'Home' },
    { url: 'html-introduction', name: 'Introduction' },
    { url: 'html-elements', name: 'Elements' },
    { url: 'html-attributes', name: 'Attributes' },
    { url: 'html-headings', name: 'Headings' },
    { url: 'html-paragraphs', name: 'Paragraphs' },
    { url: 'html-links', name: 'Links' },
    { url: 'html-formatting', name: 'Formatting' },
    { url: 'html-styles', name: 'Styles' },
    { url: 'html-images', name: 'Images' },
    { url: 'html-tables', name: 'Tables' },
    { url: 'html-lists', name: 'Lists' },
    { url: 'html-forms', name: 'Forms' },
    { url: 'html-iframes', name: 'Iframes' },  
    { url: 'html-javascript', name: 'Javascript' },
    { url: 'html-layout', name: 'Layout' },
    { url: 'html-head', name: 'Head' },
  ];

  ngOnInit() {
  }
}
