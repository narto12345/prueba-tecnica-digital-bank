export interface UserGetAll {
    result: boolean,
    status: number,
    data: User[]
}

export interface User {
    id: number
    name: string
    birthdate: string
    gender: string
    birthdateFormatted: string
}