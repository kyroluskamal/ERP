import { trigger, state, style, animate, transition, query, group } from '@angular/animations';

export const routerAnimation =
  trigger("DashboardRouterAnimation", [
    transition('*<=>*', [
      query(":enter, :leave",
        style({ position: 'abolute', width: '100%' }), { optional: true }
      ),
      group([

        query(":enter", [
          style({ opacity: '0' }),
          animate('0.6s', style({ opacity: '1' }))
        ], { optional: true }
        ),
        query(":leave", [
          style({ opacity: '1' }),
          animate('0.6s', style({ opacity: '0' }))
        ], { optional: true }
        )
      ])
    ])
  ]);
