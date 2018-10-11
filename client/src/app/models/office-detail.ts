import { Time } from "@angular/common";
import { Room } from "./room";
import { Employee } from "./employee";

export interface OfficeDetail {
    id: string,
    name: string,
    location: string,
    OpenHour: Time,
    CloseHour: Time,
    rooms: Room[],
    employees: Employee[]
}
