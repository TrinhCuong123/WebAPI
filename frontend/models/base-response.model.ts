interface RestBase{
  status: string;
  metadata?: string
}
interface RestData<T> extends RestBase {
  data: T;
}
interface RestDataList<T> extends RestBase {
  data: T[];
}

export type { RestBase, RestData, RestDataList };