import type { RestData, RestBase } from '~/models/base-response.model'
import type { TEMPDTO } from '~/models/request/tempDTO.model.ts'

const BASE_URL = 'http://localhost:5279/api/stock'

class _TempService {
  async list() {
    const response = await $api<RestData<TEMPDTO[]>>(
        `${BASE_URL}`,
        {
            method: 'GET',
        },
    );

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
export {TempService}