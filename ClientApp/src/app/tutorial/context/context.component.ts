import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-context',
  templateUrl: './context.component.html',
  styleUrls: ['./context.component.scss']
})
export class ContextComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      console.log(params);
    });
  }

}
