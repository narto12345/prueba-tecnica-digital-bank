export type Result<T, E> = Success<T> | Failure<E>;

export type Success<T> = { status: "success"; message?: string; data: T };
export type Failure<E> = { status: "error"; message?: string; error: E };
