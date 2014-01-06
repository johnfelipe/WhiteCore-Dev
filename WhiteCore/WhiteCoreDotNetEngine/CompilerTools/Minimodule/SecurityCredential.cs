/*
 * Copyright (c) Contributors, http://whitecore-sim.org/, http://aurora-sim.org
 * See CONTRIBUTORS.TXT for a full list of copyright holders.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the WhiteCore-Sim Project nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using WhiteCore.Framework;
using WhiteCore.Framework.SceneInfo;
using OpenMetaverse;

namespace WhiteCore.ScriptEngine.WhiteCoreDotNetEngine.MiniModule
{
    internal class SecurityCredential : ISecurityCredential
    {
        private readonly ISocialEntity m_owner;
        private readonly IScene m_scene;

        public SecurityCredential(ISocialEntity m_owner, IScene m_scene)
        {
            this.m_owner = m_owner;
            this.m_scene = m_scene;
        }

        #region ISecurityCredential Members

        public ISocialEntity owner
        {
            get { return m_owner; }
        }

        public bool CanEditObject(IObject target)
        {
            return m_scene.Permissions.CanEditObject(target.GlobalID, m_owner.GlobalID);
        }

        public bool CanEditTerrain(int x, int y)
        {
            return m_scene.Permissions.CanTerraformLand(m_owner.GlobalID, new Vector3(x, y, 0));
        }

        #endregion
    }
}