import { Time } from "@angular/common";

export interface CreateOffice {
    name: string,
    location: string,
    OpenHour: Time,
    CloseHour: Time
}
