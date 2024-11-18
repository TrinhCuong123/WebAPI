import type { RestData, RestBase } from '~/models/base-response.model'
import type { TEMPDTO } from '~/models/request/tempDTO.model.ts'

class _TempService {
  async list() {
    console.log(111);
    const response = await $fetch<RestData<TEMPDTO[]>>(
        `/api/stock`,
        {
            method: 'GET',
        },
    );
    console.log(response)
    if (response && response.status) {
        return response.data;
    }
    return [];
  }
  async searchManageModel(id: any) {
    const res = await useFetch<RestBase>(`https://cbrm-api.vggisopen.com/api/mohinh-quanly-rrtt`, {
      method: 'GET',
      body: id,
    });
    if (res && res.data.value?.status) {
      return res.status;
    }
    return null;
  }
}
const TempService = new _TempService();
export default TempService;