import { trigger, transition, style, animate, state, animation, keyframes, useAnimation } from '@angular/animations';


export let fade = trigger('fade', [
    state('void', style({ backgroundColor: 'yellow', opacity: 0 })),
    transition(':enter, :leave', [ // 'void => *, * => void'
        animate(1000)
    ])
]);


// create with keyframes
export let bounceOuterLeftAnimation = animation(
    animate('0.5s ease-out', keyframes([
        style({
            offset: .2,
            opacity: 1,
            transform: 'translateX(20px)'
        }),
        style({
            offset: 1,
            opacity: 0,
            transform: 'translateX(-100px)'
        })
    ])));



export let slide = trigger('slide', [
    transition(':enter', [
        style({ transform: 'translateX(-10px)' }),
        animate(2000)
    ]),
    transition(':leave',
        useAnimation(bounceOuterLeftAnimation)
    )
]);
