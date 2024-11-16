import { Routes } from '@angular/router';
import { ListComponent } from './page/list/list.component';
import { NewComponent } from './page/new/new.component';
import { NotFoundComponent } from './page/not-found/not-found.component';
import { UpdateComponent } from './page/update/update.component';

export const routes: Routes = [
    // Define routes by specifying the path and the component that should be loaded for it
    {
        path: "overview",
        component: ListComponent
    },
    {
        path: "new",
        component: NewComponent
    },
    // We define a route and a route parameter by using ":id"
    // The id parameter value will be whatever is passed after the "update/" route
    {
        path: "update/:id",
        component: UpdateComponent
    },
    // If the user goes to the base url we want to redirect them to the overview page as a sort of "homepage"
    {
        path: "",
        redirectTo: "overview",
        pathMatch: 'full'
    },
    // If the requested route did not match on any of the above routes we show a basic NotFound page
    // This is done by defining a wildcard path ("**")
    {
        path: "**",
        component: NotFoundComponent
    }
];
